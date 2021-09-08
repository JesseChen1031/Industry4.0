<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="production.aspx.cs" Inherits="_1205afternoon.production" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>生产界面</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="order.aspx">订单界面</a>
            <a href="watch.aspx">看板界面</a>
            <a href="production.aspx">生产界面</a>
        </div>
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
            </asp:Timer>
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                     当前系统的生产模式<asp:TextBox ID="tb_mode" runat="server" Enabled="False"></asp:TextBox>
                </p>
                <p>
                    传送带当前速度<asp:TextBox ID="tb_speed" runat="server" Enabled="False"></asp:TextBox>
                </p>
                <p>
                    移载机水平方向的位置<asp:TextBox ID="tb_pos" runat="server" Enabled="False"></asp:TextBox>
                </p>
            </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />

             </Triggers>
        </asp:UpdatePanel>
        
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            移载机原点偏移量<asp:TextBox ID="tb_offset" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btn_write" runat="server" Text="写入" OnClick="btn_write_Click" />
    </form>
</body>
</html>
