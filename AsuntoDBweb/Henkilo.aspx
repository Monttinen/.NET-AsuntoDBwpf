<%@ Page Title="Henkilöt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Henkilo.aspx.cs" Inherits="AsuntoDBweb.Henkilo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:GridView ID="gridHenkilo" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        CssClass="grid" OnRowCommand="gridHenkilo_RowCommand"
        DataKeyNames="Avain" CellPadding="4" ForeColor="#333333"
        GridLines="None" OnRowCancelingEdit="gridHenkilo_RowCancelingEdit"
        OnRowEditing="gridHenkilo_RowEditing"
        OnRowUpdating="gridHenkilo_RowUpdating"
        OnRowDataBound="gridHenkilo_RowDataBound"
        OnRowDeleting="gridHenkilo_RowDeleting">
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
            <asp:TemplateField HeaderText="Etunimi">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEtunimi" runat="server" Text='<%# Bind("Etunimi") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEtunimi" runat="server" ControlToValidate="txtEtunimi"
                        Display="Dynamic" ErrorMessage="Etunimi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEtunimi" runat="server" Text='<%# Bind("Etunimi") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtEtunimiNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valEtunimiNew" runat="server" ControlToValidate="txtEtunimiNew"
                        Display="Dynamic" ErrorMessage="Etunimi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sukunimi">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSukunimi" runat="server" Text='<%# Bind("Sukunimi") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valSukunimi" runat="server" ControlToValidate="txtSukunimi"
                        Display="Dynamic" ErrorMessage="Sukunimi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSukunimi" runat="server" Text='<%# Bind("Sukunimi") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSukunimiNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valSukunimiNew" runat="server" ControlToValidate="txtSukunimiNew"
                        Display="Dynamic" ErrorMessage="Sukunimi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Henkilonumero">
                <EditItemTemplate>
                    <asp:TextBox ID="txtHenkilonumero" runat="server" Text='<%# Bind("Henkilonumero") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valHenkilonumero" runat="server" ControlToValidate="txtHenkilonumero"
                        Display="Dynamic" ErrorMessage="Henkilonumero puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblHenkilonumero" runat="server" Text='<%# Bind("Henkilonumero") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtHenkilonumeroNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valHenkilonumeroNew" runat="server" ControlToValidate="txtHenkilonumeroNew"
                        Display="Dynamic" ErrorMessage="Henkilonumero puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Syntymaaika">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSyntymaaika" runat="server" Text='<%# Bind("Syntymaaika") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valSyntymaaika" runat="server" ControlToValidate="txtSyntymaaika"
                        Display="Dynamic" ErrorMessage="Syntymaaika puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSyntymaaika" runat="server" Text='<%# Bind("Syntymaaika") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSyntymaaikaNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valSyntymaaikaNew" runat="server" ControlToValidate="txtSyntymaaikaNew"
                        Display="Dynamic" ErrorMessage="Syntymaaika puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sukupuoli">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSukupuoli" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valSukupuoli" runat="server" ControlToValidate="ddlSukupuoli"
                        Display="Dynamic" ErrorMessage="Sukupuoli puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSukupuoli" runat="server" Text='<%# Bind("Sukupuoli.Selite") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlSukupuoliNew" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valSukupuoliNew" runat="server" ControlToValidate="ddlSukupuoliNew"
                        Display="Dynamic" ErrorMessage="Sukupuoli puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkValitseHenkilo" runat="server" Text="Valitse Henkilo" CommandName="ValitseHenkilo" ToolTip="Valitse Henkilo"
                        CommandArgument='<%# Bind("Avain") %>'><img src="../Images/dots7.png" width="16" height="16"/></asp:LinkButton>
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
    <p />
</asp:Content>
