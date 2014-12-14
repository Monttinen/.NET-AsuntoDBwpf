<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asunto.aspx.cs" Inherits="AsuntoDBweb.Asunto1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdAsunto" runat="server" DataSourceID="AsuntoDB" AllowSorting="True" AutoGenerateColumns="False" >
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Osoite" HeaderText="Osoite" SortExpression="Osoite"></asp:BoundField>
            <asp:BoundField DataField="Asuntonumero" HeaderText="Asuntonumero" SortExpression="Asuntonumero"></asp:BoundField>
            <asp:BoundField DataField="Pinta_ala" HeaderText="Pinta_ala" SortExpression="Pinta_ala"></asp:BoundField>
            <asp:BoundField DataField="Huonelukumaara" HeaderText="Huonelukumaara" SortExpression="Huonelukumaara"></asp:BoundField>
            <asp:CheckBoxField DataField="Omistusasunto" HeaderText="Omistusasunto" SortExpression="Omistusasunto"></asp:CheckBoxField>
            <asp:TemplateField HeaderText="Asuntotyyppi" SortExpression="Asuntotyyppi">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownAsuntotyyppi" runat="server"
                        DataSourceID="AsuntoTyyppi" DataTextField="Selite" DataValueField="Koodi"
                        SelectedValue='<%# Bind("Selite") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Selite") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="AsuntoDB" runat="server"
        ConnectionString="<%$ ConnectionStrings:AsuntoDBConnectionString %>"
        SelectCommand="SELECT a.*, at.* FROM [Asunto] AS a INNER JOIN Asuntotyyppi AS at on a.AsuntotyyppiKoodi = at.Koodi"></asp:SqlDataSource>
    <asp:SqlDataSource ID="AsuntoTyyppi" runat="server"
        ConnectionString="<%$ ConnectionStrings:AsuntoDBConnectionString %>"
        SelectCommand="SELECT * FROM [Asuntotyyppi]"></asp:SqlDataSource>
    <p>
    </p>
</asp:Content>
