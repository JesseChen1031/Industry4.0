using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc;
using OpcUaHelper;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form //Form1继承了Form，Form是一个基类
    {

        //数据连接最基本需要的两个对象
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        //private SqlDataAdapter adapter = null;
        //为了方便，设为全局对象的sql语句
        private string sql = null;

        //打开数据库
        public void openDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=172.21.0.34;Initial Catalog=testapi;Persist Security Info=True;User ID=sa;Password=123456";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //Response.Write("<script>alert('Connected!');</script>");
            }
        }

       
        //封装的数据库语句执行的方法
    

       

      

        /// <summary>
        /// 这是一个文档注释
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        private OpcUaClient m_OpcUaClient = new OpcUaClient();

        private string[] MonitorNodeTags = null;
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await m_OpcUaClient.ConnectServer("opc.tcp://192.168.1.1:4840");
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException("Connected Failed", ex);
            }

            MessageBox.Show("连接成功");
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_OpcUaClient.Disconnect();
        }

        
     

        private void login_Click(object sender, EventArgs e)
        {
            
            using (FormBrowseServer form = new FormBrowseServer())
            {
                form.ShowDialog();
            }
        }

        private  async void read1_Click(object sender, EventArgs e)
        {
            try
            {
                UInt16 value = await m_OpcUaClient.ReadNodeAsync<UInt16>("ns=2;s=通道 1.设备 1.标记 2");
                readBOX1.Text = value.ToString();
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
            
        }

        private async void Write1_Click(object sender, EventArgs e)
        {
            try
            {
                await m_OpcUaClient.WriteNodeAsync("ns=3;s=\"X1\"", Byte.Parse(writeBOX.Text));
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
            
        }

        private async void batchread_Click(object sender, EventArgs e)
        {
            try
            {
                // 添加所有的读取的节点，此处的示例是类型不一致的情况
                List<NodeId> nodeIds = new List<NodeId>();
                nodeIds.Add(new NodeId("ns=2;s=通道 1.设备 1.标记 1"));
                nodeIds.Add(new NodeId("ns=2;s=_System._DateTime"));
               

                // dataValues按顺序定义的值，每个值里面需要重新判断类型
                List<DataValue> dataValues = await  m_OpcUaClient.ReadNodesAsync(nodeIds.ToArray());

                readBOX1.Text = dataValues[0].ToString();
                readBOX2.Text = dataValues[1].ToString();



                // 如果你批量读取的值的类型都是一样的，比如float，那么有简便的方式

                /* 
                 List<string> tags = new List<string>();
                 tags.Add("ns=2;s=Devices/分厂一/车间二/ModbusTcp客户端/风俗");
                 tags.Add("ns=2;s=Devices/分厂一/车间二/ModbusTcp客户端/转速");


                 // 按照顺序定义的值
                 List<float> values = m_OpcUaClient.ReadNodes<float>(tags.ToArray());

                 */

            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }

        private  void batchwrite_Click(object sender, EventArgs e)
        {
            try
            {
                // 此处演示写入一个short，2个float类型的数据批量写入操作
                 bool success =  m_OpcUaClient.WriteNodes(new string[] {
                      "ns=2;s=通道 1.设备 1.标记 1",
                      "ns=2;s=通道 1.设备 1.标记 2"},
                    new object[] {
                          (UInt16)2345,
                          (UInt16) 666,
                                 });
                if (success)
                {
                    // 写入成功
                }
                else
                {
                    // 写入失败，一个失败即为失败
                }
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }

        }

        private void subscribe_Click(object sender, EventArgs e)
        {
            m_OpcUaClient.AddSubscription("A", "ns=2;s=_System._DateTime", SubCallback);

            
        }
        private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs>(SubCallback), key, monitoredItem, args);
                return;
            }

            if (key == "A")
            {
                // 如果有多个的订阅值都关联了当前的方法，可以通过key和monitoredItem来区分
                MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
                if (notification != null)
                {
                    textBox3.Text = notification.Value.WrappedValue.Value.ToString();
                }
            }

            else if (key == "B")
            {
                // 需要区分出来每个不同的节点信息
                MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
                if (monitoredItem.StartNodeId.ToString() == MonitorNodeTags[0])
                {
                    batchsub1.Text = notification.Value.WrappedValue.Value.ToString();
                }
                else if (monitoredItem.StartNodeId.ToString() == MonitorNodeTags[1])
                {
                    batchsub2.Text = notification.Value.WrappedValue.Value.ToString();
                }
                else if (monitoredItem.StartNodeId.ToString() == MonitorNodeTags[2])
                {
                    batchsub3.Text = notification.Value.WrappedValue.Value.ToString();
                }
            }
        }

        
        private void batchSubscribe_Click(object sender, EventArgs e)
        {
            // 多个节点的订阅
            MonitorNodeTags = new string[]
            {
                   
            };
            m_OpcUaClient.AddSubscription("B", MonitorNodeTags, SubCallback);
        }

        private void start_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                m_OpcUaClient.WriteNode<Boolean>("ns=3;s=\"tingz\"", true);
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }

        private void start_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                m_OpcUaClient.WriteNode<Boolean>("ns=3;s=\"tingz\"", false);
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }

        private void stop_MouseDown(object sender, MouseEventArgs e)
        {

            try
            {
                m_OpcUaClient.WriteNode<Boolean>("ns=3;s=\"tingz\"", true);
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }

        }

        private void stop_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {
                m_OpcUaClient.WriteNode<Boolean>("ns=3;s=\"tingz\"", true);
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }

        }

        private void ReadFormDb_Click(object sender, EventArgs e)
        {
            sql = "select TOP 1 part_id from order_pos order by order_pos_id desc";
            openDatabase();
            cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                writeBOX.Text = (String)dr[0].ToString().Trim();
               
            }
            conn.Close();
            
        }
    }


    





}

    
