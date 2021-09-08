using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1205afternoon
{
    public partial class production : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 500;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (tcpFunc.hasProductionInfo)
            {
                switch (tcpFunc.productionInfo[0])
                {
                    case (0):
                        tb_mode.Text = "手动模式";
                        break;
                    case (1):
                        tb_mode.Text = "自动模式";
                        break;
                }

                tb_speed.Text = Encoding.UTF8.GetString(tcpFunc.productionInfo.Skip(4).Take(4).ToArray());
                tb_pos.Text = Encoding.UTF8.GetString(tcpFunc.productionInfo.Skip(10).Take(4).ToArray());
            }
        }

        protected void btn_write_Click(object sender, EventArgs e)
        {
            if (tcpFunc.hasProductionInfo)
            {
                byte[] prefix = tcpFunc.productionInfo.Skip(0).Take(14).ToArray();
                byte[] suffix = BitConverter.GetBytes(Int32.Parse(tb_offset.Text));
                Array.Reverse(suffix);
                byte[] info = prefix.Concat(suffix).ToArray();
                tcpFunc.Clients["192.168.3.11:2002"].Send(info);
            }
           
        }
    }
}