<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Henkilo.aspx.cs" Inherits="AsuntoDBweb.Henkilo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdHenkilo" runat="server" AutoGenerateColumns="False" DataKeyNames="Avain" DataSourceID="AsuntoDB" AllowSorting="True">
        <AlternatingRowStyle BackColor="#dddddd" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Avain" HeaderText="Avain" InsertVisible="False" ReadOnly="True" SortExpression="Avain" Visible="False" />
            <asp:BoundField DataField="Sukunimi" HeaderText="Sukunimi" SortExpression="Sukunimi" />
            <asp:BoundField DataField="Etunimi" HeaderText="Etunimi" SortExpression="Etunimi" />
            <asp:BoundField DataField="Syntymaaika" HeaderText="Syntymäaika" SortExpression="Syntymaaika" />
             <asp:TemplateField HeaderText="Sukupuoli" SortExpression="Sukupuoli">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownSukupuoli" runat="server"
                        DataSourceID="Sukupuoli" DataTextField="Selite" DataValueField="Koodi"
                        SelectedValue='<%# Bind("Koodi") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Sukupuoli") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="AsuntoDB" runat="server" ConnectionString="<%$ ConnectionStrings:AsuntoDBEntities %>"
        SelectCommand="SELECT Henkilo.Avain as Avain, Henkilo.Sukunimi AS Sukunimi,Henkilo.Etunimi AS Etunimi, Henkilo.Syntymaaika as Syntymaaika, Sukupuoli.Selite AS Sukupuoli, Sukupuoli.Koodi FROM Henkilo INNER JOIN Sukupuoli ON Henkilo.SukupuoliKoodi = Sukupuoli.Koodi"
        DeleteCommand="DELETE FROM Henkilo where avain = @avain" InsertCommand="INSERT into henkilo (Etunimi,Sukunimi,Syntymaaika,SukupuoliKoodi) values(@etunimi,@sukunimi,@syntymaaika,@sukupuoli)"
        UpdateCommand="UPDATE Henkilo SEt Etunimi = @etunimi, Sukunimi = @sukunimi where avain = @avain">
        <DeleteParameters>
            <asp:Parameter Name="avain" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="etunimi" />
            <asp:Parameter Name="sukunimi" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="etunimi" />
            <asp:Parameter Name="sukunimi" />
            <asp:Parameter Name="avain" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sukupuoli" runat="server"
        ConnectionString="<%$ ConnectionStrings:AsuntoDBConnectionString %>"
        SelectCommand="SELECT * FROM [Sukupuoli]"></asp:SqlDataSource>
    <p>
    </p>
</asp:Content>
