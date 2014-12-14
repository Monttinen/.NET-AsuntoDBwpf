<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asuntotyyppi.aspx.cs" Inherits="AsuntoDBweb.Asuntotyyppi1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:GridView ID="grdAsuntotyyppi" runat="server" DataSourceID="AsuntoDB" AllowSorting="True" AutoGenerateColumns="False" >
        <AlternatingRowStyle BackColor="#dddddd" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Selite" HeaderText="Asuntotyyppi" SortExpression="Selite"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="AsuntoDB" runat="server"
        ConnectionString="<%$ ConnectionStrings:AsuntoDBConnectionString %>"
        SelectCommand="SELECT * FROM [Asuntotyyppi]"></asp:SqlDataSource>
</asp:Content>
