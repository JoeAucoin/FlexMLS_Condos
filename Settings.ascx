<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.FlexMLS_Condos.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="ModuleName1 Settings Design Table">
	<tr>
		<td class="SubHead" style="width:150px;"><dnn:label id="lblFlexMLSModule" runat="server" suffix=":" controlname="ddlFlexMLSModule"></dnn:label></td>
		<td valign="bottom">
			<asp:dropdownlist id="ddlFlexMLSModule" Runat="server" datavaluefield="TabID" datatextfield="TabName"></asp:dropdownlist>
		</td>
	</tr>
	<tr>
		<td class="SubHead" style="width:150px;"><dnn:label id="lblDefaultTown" runat="server" suffix=":" controlname="txtDefaultTown"></dnn:label></td>
		<td valign="bottom">
			<asp:Textbox id="txtDefaultTown" Runat="server" />
	</tr>    	
</table>