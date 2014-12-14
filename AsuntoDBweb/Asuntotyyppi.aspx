<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asuntotyyppi.aspx.cs" Inherits="AsuntoDBweb.Asuntotyyppi1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:GridView ID="gridAsuntotyyppi" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        CssClass="grid" CellPadding="4" ForeColor="#333333" GridLines="None"
        DataKeyNames="Koodi" 
        OnRowCommand="gridAsuntotyyppi_RowCommand"
        OnRowCancelingEdit="gridAsuntotyyppi_RowCancelingEdit"
        OnRowEditing="gridAsuntotyyppi_RowEditing"
        OnRowUpdating="gridAsuntotyyppi_RowUpdating"
        OnRowDataBound="gridAsuntotyyppi_RowDataBound"
        OnRowDeleting="gridAsuntotyyppi_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                        CommandArgument=''><img src="../Images/list93.png" width="16" height="16"/></asp:LinkButton>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                        ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                        CommandArgument=''><img src="../Images/cross106.png" width="16" height="16"/></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                        CommandArgument=''><img src="../Images/tick11.png"width="16" height="16" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                        CommandArgument=''><img src="../Images/refresh69.png" width="16" height="16"/></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add New Entry"
                        CommandArgument=''><img src="../Images/add200.png" width="16" height="16"/></asp:LinkButton>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancel"
                        CommandArgument=''><img src="../Images/refresh69.png" width="16" height="16"/></asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Asuntotyyppi">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAsuntotyyppi" runat="server" Text='<%# Bind("Selite") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAsuntotyyppi" runat="server" ControlToValidate="txtAsuntotyyppi"
                        Display="Dynamic" ErrorMessage="Asuntotyyppi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAsuntotyyppi" runat="server" Text='<%# Bind("Selite") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAsuntotyyppiNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAsuntotyyppiNew" runat="server" ControlToValidate="txtAsuntotyyppiNew"
                        Display="Dynamic" ErrorMessage="Asuntotyyppi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
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
</asp:Content>
