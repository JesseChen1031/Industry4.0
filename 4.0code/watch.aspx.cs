using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1205afternoon
{
    public partial class WebForm1 : System.Web.UI.Page
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
            Timer1.Interval=500;
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (tcpFunc.hasWatchInfo)
            {
                
                tb_totalNum.Text = getNum(tcpFunc.watchInfo[0].ToString());
                tb_num.Text = tcpFunc.watchInfo[1].ToString();
                switch (tcpFunc.watchInfo[0])
                {
                    case (0):
                        tb_type.Text = "NULL";
                        tb_num.Text = "0";
                        tb_totalNum.Text = "0";
                        break;
                    case (1):
                        tb_type.Text = "C101";
                        break;
                    case (2):
                        tb_type.Text = "C102";
                        break;
                    case (3):
                        tb_type.Text = "C103";
                        break;
                    case (4):
                        tb_type.Text = "C104";
                        break;
                }

               
                
                
            }
        }

        

        public string getNum(string id)
        {
            openDatabase();
            cmd = new SqlCommand("select num from products where id ='" + id + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string num = dr[0].ToString().Trim();
                conn.Close();
                return num;
            }
            else
            {
                conn.Close();
                return "0";
            }
}
    }
}