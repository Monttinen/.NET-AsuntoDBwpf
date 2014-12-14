<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Henkilo.aspx.cs" Inherits="AsuntoDBweb.Henkilo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdHenkilo" runat="server" AutoGenerateColumns="False" DataKeyNames="Avain" DataSourceID="AsuntoDB" AllowSorting="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Avain" HeaderText="Avain" InsertVisible="False" ReadOnly="True" SortExpression="Avain" Visible="False" />
            <asp:BoundField DataField="Sukunimi" HeaderText="Sukunimi" SortExpression="Sukunimi" />
            <asp:BoundField DataField="Etunimi" HeaderText="Etunimi" SortExpression="Etunimi" />
            <asp:BoundField DataField="Syntymaaika" HeaderText="Syntymäaika" SortExpression="Syntymaaika" />
            <asp:BoundField DataField="Sukupuoli" HeaderText="Sukupuoli" SortExpression="Sukupuoli" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="AsuntoDB" runat="server" ConnectionString="<%$ ConnectionStrings:AsuntoDBEntities %>"
        SelectCommand="SELECT Henkilo.Avain as Avain, Henkilo.Sukunimi AS Sukunimi,Henkilo.Etunimi AS Etunimi, Henkilo.Syntymaaika as Syntymaaika, Sukupuoli.Selite AS Sukupuoli FROM Henkilo INNER JOIN Sukupuoli ON Henkilo.SukupuoliKoodi = Sukupuoli.Koodi"
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
    <p>
    </p>
</asp:Content>
