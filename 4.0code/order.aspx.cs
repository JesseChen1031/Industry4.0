using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1205afternoon
{
    public partial class order : System.Web.UI.Page
    {

        public SqlCommand cmd = null;
        public SqlConnection conn = null;
        public string sql = null;

        public void openDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=1205afternoon;User ID=sa;Password=123456";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

        }

        public void execute(string sql)
        {
            openDatabase();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 500;
            if (tcpFunc.serverOpened)
            {
                btn_server.Text = "关闭服务器";
            }
            else
            {
                btn_server.Text = "打开服务器";
            }

            

            
        }

        protected void btn_server_Click(object sender, EventArgs e)
        {
            if (btn_server.Text == "关闭服务器")
            {
                tcpFunc.server(1);
                btn_server.Text = "打开服务器";
            }
            else if (btn_server.Text == "打开服务器")
            {
                tcpFunc.server(0);
                btn_server.Text = "关闭服务器";
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if(tcpFunc.hasOrderInfo && tcpFunc.orderInfo[0] == 0)
            {
                downLoadInfo(dl_type.SelectedValue,tb_num.Text);

            }
            else
            {
                Response.Write("<script>alert('目前不能下单')</script>");
            }
        }

        private void downLoadInfo(string type, string num)
        {
            byte[] prefix = new byte[2] { 04, 04 };
            byte[] orderInfo = new byte[2]
            {
                    byte.Parse(type),byte.Parse(num)
            };

            string typeInfo = null;
            switch (type)
            {
                case ("1"):
                    typeInfo = "C101";
                    break;
                case ("2"):
                    typeInfo = "C102";
                    break;
                case ("3"):
                    typeInfo = "C103";
                    break;
                case ("4"):
                    typeInfo = "C104";
                    break;
            }

            string numInfo = null;
            for (int i = 0; i < 4-num.Length; i++)
            {
                numInfo += "0";
            }

            numInfo += num;

            byte[] downloadInfo = new byte[] { };

            downloadInfo = downloadInfo.Concat(orderInfo)
                .Concat(prefix).Concat(Encoding.UTF8.GetBytes(DateTime.Now.ToString("HHmm")))
                .Concat(prefix).Concat(Encoding.UTF8.GetBytes(typeInfo))
                .Concat(prefix).Concat(Encoding.UTF8.GetBytes(numInfo))
                .Concat(prefix).Concat(Encoding.UTF8.GetBytes(DateTime.Now.ToString("HHmm"))).ToArray();

            tcpFunc.Clients["192.168.3.11:2000"].Send(downloadInfo);
        }

        protected void btn_check_Click(object sender, EventArgs e)
        {
            dl_clients.Items.Clear();
            string[] clients = tcpFunc.Clients.Keys.ToArray();
            for (int i = 0; i < clients.Length; i++)
            {
                dl_clients.Items.Add(clients[i]);
            }
        }

        protected void btn_reserve_Click(object sender, EventArgs e)
        {
            sql = "insert into orders(type,num) values('" + dl_type.SelectedValue + "','" + tb_num.Text + "')";
            execute(sql);
            GridView1.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (tcpFunc.hasOrderInfo && tcpFunc.orderInfo[0] == 0)
            {
                updateOrders();
                openDatabase();
                cmd = new SqlCommand("select Top 1 * from orders where status ='未开始' order by id asc", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr[0].ToString().Trim();
                    downLoadInfo(dr[1].ToString().Trim(), dr[2].ToString().Trim());
                    sql = "update orders set status = '进行中' where id ='" + id + "'";
                    execute(sql);
                    conn.Close();
                }

            }

            GridView1.DataBind();
        }

        public void updateOrders()
        {
            openDatabase();
            cmd = new SqlCommand("select TOP 1 id from orders where status ='进行中' order by id asc", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string id = dr[0].ToString().Trim();   
                sql = "update orders set status = '已完成', finTime = '"+DateTime.Now+"' where id ='" + id + "'";
                execute(sql);
                conn.Close();
            }
        }
        
    }
}