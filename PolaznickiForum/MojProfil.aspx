<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="PolaznickiForum.MojProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Moj Progfil</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblKorisnik" runat="server" Text=""></asp:Label>

    [<asp:Label ID="lblGrupa" runat="server" Text=""></asp:Label>
    ]<br />
    <br />
    <p>
        <asp:Label ID="lblInfo" runat="server" Text="...."></asp:Label></p>
    <h2>Uredi password: </h2>
    <p>Stari password:<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>

    </p>
    <p>Novi password:<asp:TextBox ID="txtNewPwd1" runat="server"></asp:TextBox>
    </p>
    <p>Novi pwd opet:<asp:TextBox ID="txtNewPwd2" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnUrediPwd" runat="server" Text="Uredi password" OnClick="btnUrediPwd_Click" />
    </p>
    <h2>E-mail:</h2>
    <p>
        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnUrediMail" runat="server" Text="Uredi mail" OnClick="btnUrediMail_Click" />
    </p>
    <p>&nbsp;</p>
    
</asp:Content>
