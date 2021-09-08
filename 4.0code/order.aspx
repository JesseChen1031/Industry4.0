<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="_1205afternoon.order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="order.aspx">订单界面</a>
            <a href="watch.aspx">看板界面</a>
            <a href="production.aspx">生产界面</a>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
            </asp:Timer>
            
        </div>
        <p>
            <asp:Button ID="btn_server" runat="server" OnClick="btn_server_Click" Text="打开服务器" />
            <asp:DropDownList ID="dl_clients" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btn_check" runat="server" OnClick="btn_check_Click" Text="查看客户端" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            选择产品类型<asp:DropDownList ID="dl_type" runat="server">
                <asp:ListItem Value="1">C101</asp:ListItem>
                <asp:ListItem Value="2">C102</asp:ListItem>
                <asp:ListItem Value="3">C103</asp:ListItem>
                <asp:ListItem Value="4">C104</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            产品数量<asp:TextBox ID="tb_num" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="立即下单" />
        <asp:Button ID="btn_reserve" runat="server" OnClick="btn_reserve_Click" Text="暂存订单" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        暂存订单列表
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="num" HeaderText="num" SortExpression="num" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="finTime" HeaderText="finTime" SortExpression="finTime" />
            </Columns>
        </asp:GridView>
            </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:1205afternoonConnectionString %>" SelectCommand="SELECT * FROM [orders]"></asp:SqlDataSource>
    </form>
</body>
</html>
