<%@ Page Title="Asunnon valinta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsunnonValinta.aspx.cs" Inherits="AsuntoDBweb.AsunnonValinta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    <p>
        <b>Valittu henkilö:</b><asp:Label ID="lblValittuHenkilo" runat="server" Text="" />
    </p>
    <p>
        <b>Valitun henkilön asunto:</b><asp:Label ID="lblValitunHenkilonAsunto" runat="server" Text="" />
    </p>
    <asp:GridView ID="gridAsunnonValinta" runat="server" AutoGenerateColumns="True"
        CssClass="grid" CellPadding="4" ForeColor="#333333" GridLines="None"
        DataKeyNames="Avain"
        OnRowCommand="gridAsunnonValinta_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkValitse" runat="server" Text="" CommandName="Valitse" ToolTip="Valitse"
                        CommandArgument='<%# Bind("Avain") %>'><img src="../Images/check59.png" width="16" height="16"/></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <p>
        <asp:LinkButton ID="lnkPoista" runat="server" CommandName="Poista" ToolTip="Poista" OnClick="lnkPoista_Click">Poista Asunto</asp:LinkButton>
    </p>
</asp:Content>
