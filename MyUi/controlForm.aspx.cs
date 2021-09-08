using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Opc;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper.Forms;
using OpcUaHelper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using System.Data;

namespace MyUi
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private SqlCommand cmd = null;
        private SqlConnection conn = null;
        private string sql = null;
        public static OpcUaClient opcUaClient = new OpcUaClient();
        private string[] MonitorNodes = new string[] 
        {
            "ns=2;s=模拟器示例.函数.Ramp1",
            "ns=2;s=模拟器示例.函数.Ramp3",
            "ns=2;s=模拟器示例.函数.Ramp4",
            "ns=2;s=模拟器示例.函数.Ramp5",
        };

        public void openDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=testapi;Persist Security Info=True;User ID=sa;Password=123456";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void writeDeviceState(String deviceName, String deviceState)
        {
            openDatabase();
            cmd = new SqlCommand("update deviceOWs set deviceState='" + deviceState + "' where deviceName=N'" + deviceName + "'", conn); //若表名和列名有变化，记得更新
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void writeOrderStatus(String orderId)
        {
            openDatabase();
            cmd = new SqlCommand("update orders set status= 1 where id=" + orderId, conn); //若表名和列名有变化，记得更新
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Invoke(Action<string, MonitoredItem, MonitoredItemNotificationEventArgs> action, string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            throw new NotImplementedException();
        }

        public bool InvokeRequired { get; private set; }

        private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs>(SubCallback), key, monitoredItem, args);
                return;
            }

            else if (key == "B")
            {
                // 需要区分出来每个不同的节点信息
                MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
                if (monitoredItem.StartNodeId.ToString() == MonitorNodes[0])
                {
                    //string script = "$('#tb_Test').val("+notification.Value.WrappedValue.Value.ToString()+");";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", script, true);
                    writeDeviceState("设备1", notification.Value.WrappedValue.Value.ToString());
                }
                else if (monitoredItem.StartNodeId.ToString() == MonitorNodes[1])
                {
                    writeDeviceState("设备2", notification.Value.WrappedValue.Value.ToString());
                }
                else if (monitoredItem.StartNodeId.ToString() == MonitorNodes[2])
                {
                    writeDeviceState("设备3", notification.Value.WrappedValue.Value.ToString());
                }
                else if (monitoredItem.StartNodeId.ToString() == MonitorNodes[3])
                {
                    writeDeviceState("设备4", notification.Value.WrappedValue.Value.ToString());
                }

            }
        }

      

        protected void Page_Load(object sender, EventArgs e)
        {

            //opcUaClient.ConnectServer("opc.tcp://192.168.1.1:4840");
            // 多个节点的订阅
            // opcUaClient.AddSubscription("B", MonitorNodes, SubCallback);
            // openDatabase();

        }

        protected void btn_Start1_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)true);
        }

        protected void btn_Start2_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)false);
        }

        protected void btn_Stop1_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)true);
        }

        protected void btn_Stop2_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)false);
        }

        protected void btn_Reset1_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)true);
        }

        protected void btn_Reset2_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)false);
        }

        protected void btn_HandMode_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)true);
        }

        protected void btn_AutoMode_Click(object sender, EventArgs e)
        {
            opcUaClient.WriteNode("node string", (bool)false);

        }


        protected void btn_sendOrder_Click(object sender, EventArgs e)
        {
           
            opcUaClient.WriteNode("ns=3;s=\"X7\"", Byte.Parse(tb_AxisMaterial.Text));
            opcUaClient.WriteNode("ns=3;s=\"X8\"", Byte.Parse(tb_SleeveMaterial.Text));
            //opcUaClient.WriteNode("node string", Byte.Parse(tb_PressTime.Text));
            opcUaClient.WriteNode("ns=3;s=\"X9\"", Byte.Parse(tb_StorePosition.Text));
            //opcUaClient.WriteNode("node string", Byte.Parse(tb_Num.Text));
            writeOrderStatus(tb_OrderId.Text);

        }
    }
}