using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using OpcUaHelper;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper.Forms;

namespace MyUi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static OpcUaClient opcUaClient = new OpcUaClient();

        protected  void Page_Load(object sender, EventArgs e)
        {
             opcUaClient.ConnectServer("opc.tcp://192.168.1.1:4840");
            
        }




        [System.Web.Services.WebMethod]
        public static void writeBin(string info)
        {
            var j = 1;
            foreach (char item in info)
            {
                
                opcUaClient.WriteNodeAsync("ns=3;s=\"X"+j+"\"", Byte.Parse(item.ToString()));
                MessageBox.Show(item.ToString());
                j++;
            }
        }

        [System.Web.Services.WebMethod]
        public static void clearSet()
        {
            for(var j =1;j<7;j++)
            {
                
                opcUaClient.WriteNodeAsync("ns=3;s=\"X"+j+"\"", Byte.Parse("0"));
                //MessageBox.Show(j.ToString());
                
            }
        }
    }
}