<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asunto.aspx.cs" Inherits="AsuntoDBweb.Asunto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:GridView ID="gridAsunto" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        CssClass="grid" OnRowCommand="gridAsunto_RowCommand"
        DataKeyNames="Avain" CellPadding="4" ForeColor="#333333"
        GridLines="None" OnRowCancelingEdit="gridAsunto_RowCancelingEdit"
        OnRowEditing="gridAsunto_RowEditing"
        OnRowUpdating="gridAsunto_RowUpdating"
        OnRowDataBound="gridAsunto_RowDataBound"
        OnRowDeleting="gridAsunto_RowDeleting">
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
            
            <asp:TemplateField HeaderText="Asuntonumero">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAsuntonumero" runat="server" Text='<%# Bind("Asuntonumero") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAsuntonumero" runat="server" ControlToValidate="txtAsuntonumero"
                        Display="Dynamic" ErrorMessage="Asuntonumero puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAsuntonumero" runat="server" Text='<%# Bind("Asuntonumero") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAsuntonumeroNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAsuntonumeroNew" runat="server" ControlToValidate="txtAsuntonumeroNew"
                        Display="Dynamic" ErrorMessage="Asuntonumero puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Osoite">
                <EditItemTemplate>
                    <asp:TextBox ID="txtOsoite" runat="server" Text='<%# Bind("Osoite") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valOsoite" runat="server" ControlToValidate="txtOsoite"
                        Display="Dynamic" ErrorMessage="Osoite puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOsoite" runat="server" Text='<%# Bind("Osoite") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtOsoiteNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valOsoiteNew" runat="server" ControlToValidate="txtOsoiteNew"
                        Display="Dynamic" ErrorMessage="Osoite puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pinta-ala">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPinta_ala" runat="server" Text='<%# Bind("Pinta_ala") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPinta_ala" runat="server" ControlToValidate="txtPinta_ala"
                        Display="Dynamic" ErrorMessage="Pinta-ala puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPinta_ala" runat="server" Text='<%# Bind("Pinta_ala") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPinta_alaNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valPinta_alaNew" runat="server" ControlToValidate="txtPinta_alaNew"
                        Display="Dynamic" ErrorMessage="Pinta_ala puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Huonelukumäärä">
                <EditItemTemplate>
                    <asp:TextBox ID="txtHuonelukumaara" runat="server" Text='<%# Bind("Huonelukumaara") %>' CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valHuonelukumaara" runat="server" ControlToValidate="txtHuonelukumaara"
                        Display="Dynamic" ErrorMessage="Huonelukumäärä puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblHuonelukumaara" runat="server" Text='<%# Bind("Huonelukumaara") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtHuonelukumaaraNew" runat="server" CssClass="" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valHuonelukumaaraNew" runat="server" ControlToValidate="txtHuonelukumaaraNew"
                        Display="Dynamic" ErrorMessage="Huonelukumäärä puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Asuntotyyppi">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlAsuntotyyppi" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valAsuntotyyppi" runat="server" ControlToValidate="ddlAsuntotyyppi"
                        Display="Dynamic" ErrorMessage="Asuntotyyppi puuttuu." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAsuntotyyppi" runat="server" Text='<%# Bind("Asuntotyyppi.Selite") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlAsuntotyyppiNew" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valAsuntotyyppiNew" runat="server" ControlToValidate="ddlAsuntotyyppiNew"
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

