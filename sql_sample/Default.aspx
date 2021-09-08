<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Timer ID="timerTest" runat="server" Interval="20000" OnTick="timerTest_Tick">  </asp:Timer>
   
    <div class="row">             
                          
                        
                           <table runat="server" id="table1">
                              <tr>
                               <td>name:</td>
                               <td>
                                  <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                               </td>
                             </tr>
                             <tr>
                               <td>age:</td>
                               <td>
                                  <asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
                               </td>
                             </tr>
                             <tr>
                                  <td><asp:Button runat="server" ID="BtnAdd" text="add" OnClick="BtnAdd_Click"/></td>
                                  <td><asp:Button runat="server" ID="BtnDel" text="del" OnClick="BtnDel_Click"/></td>
                                  <td><asp:Button runat="server" ID="BtnUpdate" text="update" OnClick="BtnUpdate_Click"/></td>
                                  <td><asp:Button runat="server" ID="BtnSelect" text="select" OnClick="BtnSelect_Click"/></td>
                             </tr>
                           </table> 
                      

     </div>  

</asp:Content>
