<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="watch.aspx.cs" Inherits="_1205afternoon.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>看板界面</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="order.aspx">订单界面</a>
            <a href="watch.aspx">看板界面</a>
            <a href="production.aspx">生产界面</a>
            <br />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     当前加工产品的产品类型<asp:TextBox ID="tb_type" runat="server" Enabled="False"></asp:TextBox>
                    <p>
                        当前批次产品的剩余待加工数量<asp:TextBox ID="tb_num" runat="server" Enabled="False"></asp:TextBox>
                    </p>
                    <p>
                        当天实际总产量<asp:TextBox ID="tb_totalNum" runat="server" Enabled="False"></asp:TextBox>
                    </p>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
       
    </form>
</body>
</html>
