<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LogError._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <br />
     <asp:Button ID="btnGenerarError" OnClick="DispararError" runat="server" Text="Generar Error" Class="btn btn-outline-danger"></asp:Button>

</asp:Content>
