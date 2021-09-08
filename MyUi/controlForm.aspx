<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlForm.aspx.cs" Inherits="MyUi.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>控制界面</title>
    <meta http-equiv="X-UA-Conpatible" content="IE=edgd, chrome=1" />
    <meta name="renderer" content="webkit" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1" />
    <link rel="stylesheet" href="css/layui.css" />
    <style>
        .textBox-item {
            margin:20px 0px 0px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="startBtns" style="margin:20px">
            <asp:Button ID="btn_Start1" runat="server" Text="启动1" OnClick="btn_Start1_Click" />
            <asp:Button ID="btn_Start2" runat="server" Text="启动2" OnClick="btn_Start2_Click" />
        </div>

        <div id="stopBtns" style="margin:20px">
             <asp:Button ID="btn_Stop1" runat="server" Text="停止1" OnClick="btn_Stop1_Click" />
             <asp:Button ID="btn_Stop2" runat="server" Text="停止2" OnClick="btn_Stop2_Click" />
        </div>
       <div id="resetBtns" style="margin:20px">
             <asp:Button ID="btn_Reset1" runat="server" Text="复位1" OnClick="btn_Reset1_Click" />
             <asp:Button ID="btn_Reset2" runat="server" Text="复位2" OnClick="btn_Reset2_Click" />
        </div>
        <div id="switchBtns" style="margin:20px">
             <asp:Button ID="btn_HandMode" runat="server" Text="手动" OnClick="btn_HandMode_Click" />
             <asp:Button ID="btn_AutoMode" runat="server" Text="自动" OnClick="btn_AutoMode_Click" />
        </div>

         <asp:TextBox ID="tb_Test" runat="server"></asp:TextBox>

        <div id="textBox-container" style="margin:100px 0px 0px 20px">
            <div class="textBox-item"> 
                 <asp:TextBox ID="tb_OrderId" runat="server"></asp:TextBox>
                 <asp:Label ID="Label6" runat="server" Text="订单编号"></asp:Label>
             </div>
             <div class="textBox-item"> 
                 <asp:TextBox ID="tb_AxisMaterial" runat="server"></asp:TextBox>
                 <asp:Label ID="Label1" runat="server" Text="轴物料"></asp:Label>
             </div>
            <div class="textBox-item">   
                <asp:TextBox ID="tb_SleeveMaterial" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="套物料"></asp:Label>
             </div>
            <div class="textBox-item">
                  
                <asp:TextBox ID="tb_PressTime" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="压合时间"></asp:Label>
                 
             </div>
            <div class="textBox-item">
                  
                <asp:TextBox ID="tb_StorePosition" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="仓储位置"></asp:Label>
             </div>
            <div class="textBox-item">
                  
                <asp:TextBox ID="tb_Num" runat="server"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="数量"></asp:Label>
             </div>
            <div id="orderBtns" style="margin-top:20px">
             <asp:Button ID="btn_ReadOrder" runat="server" Text="读取订单" />
             <asp:Button ID="btn_sendOrder" runat="server" Text="下订单" OnClick="btn_sendOrder_Click"  />
        </div>
           
        </div>
    </form>

    <script src="layui.all.js" charset="utf-8"></script>
    <script type="text/javascript">
        let $=layui.$
        $("#btn_ReadOrder").click(function () {
            //console.log("检测成功");
                $.ajax({
                type: "get",
                url: 'http://localhost:56912/api/orders/1',
                success: (res) => {
                    //console.log("获取成功");
                    $("#tb_OrderId").val(res.id);
                    $("#tb_AxisMaterial").val(res.axisMaterial);
                    $("#tb_SleeveMaterial").val(res.sleeveMaterial);
                    $("#tb_PressTime").val(res.pressTime);
                    $("#tb_StorePosition").val(res.storePosition);
                    $("#tb_Num").val(res.num);
                },
                error: (err) => {
                    console.log(err)
                }
                })
            return false;
        })
    </script>
</body>
</html>
