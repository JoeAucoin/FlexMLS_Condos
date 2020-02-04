<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewFlexMLS_Condos.ascx.cs" Inherits="GIBS.Modules.FlexMLS_Condos.ViewFlexMLS_Condos" %>
<div style="width: 90%;margin-left:auto;
    margin-right:auto;
text-align: center;">

    <div align="center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" 
            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"  
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
            GridLines="None" 
            CssClass="dnnGrid">
    <AlternatingRowStyle cssclass="dnnGridAltItem" />
    <FooterStyle cssclass="dnnGridFooter" />
    <HeaderStyle cssclass="dnnGridHeader" />
    <PagerStyle cssclass="dnnGridPager" />
    <RowStyle cssclass="dnnGridItem" />
        <Columns>


        <asp:TemplateField Headertext ="# of Units" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
               <asp:Hyperlink runat= "server" Text='<%# DataBinder.Eval(Container.DataItem,"itemCount")%>' ID="HyperlinkItemCount"/>   
            </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField Headertext ="Condominium Complex">
                <ItemTemplate>


               <asp:Hyperlink runat= "server" Text='<%# DataBinder.Eval(Container.DataItem,"Complex")%>' ID="Hyperlink2"/>   
                </ItemTemplate>
        </asp:TemplateField> 

        <asp:BoundField HeaderText="Village" DataField="Village" ItemStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Code" DataField="Description" ItemStyle-VerticalAlign="Bottom" ItemStyle-HorizontalAlign="Left" Visible="false" />
            </Columns>

        </asp:GridView>
    </div>
    <br clear="all" />
    <p>
    <asp:Repeater ID="RepeaterTowns" runat="server" OnItemDataBound="RepeaterTowns_OnItemDataBound" >
    <ItemTemplate>
    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink> | 
    </ItemTemplate>
    </asp:Repeater></p>


</div>