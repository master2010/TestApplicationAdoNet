<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PolaznickiForum.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registracija</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registracija</h1>
    <h2>Unesite potrebne podatke da se kreira racun.</h2>
    <p>Username:
        <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
    </p>
    <p>Password:
        <asp:TextBox ID="tbxPw1" runat="server"></asp:TextBox>
    </p>
    <p>Pwd again:<asp:TextBox ID="tbxPw2" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnReg" runat="server" OnClick="btnReg_Click" Text="Registracija" />
    </p>
    <p>&nbsp;</p>
    <p id="par_obj" runat="server"></p>

</asp:Content>
