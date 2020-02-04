using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.Modules.FlexMLS.Components;
using GIBS.Modules.FlexMLS_Condos.Components;
using DotNetNuke.Common;
using System.Web;

namespace GIBS.Modules.FlexMLS_Condos
{
    public partial class ViewFlexMLS_Condos : PortalModuleBase, IActionable
    {

        static string _FlexMLSPage = "";
        public string _searchTown = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //List<FlexMLS_CondosInfo> items;
                    //FlexMLS_CondosController controller = new FlexMLS_CondosController();
                    LoadSettings();
                    LoadTowns();
                    LoadCondos();

                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        public void LoadCondos()
        {

            try
            {
                //   string year = DateTime.Now.Year.ToString();
                string town = "";

                if (Request.QueryString["town"] != null)
                {
                    town = Request.QueryString["town"].ToString();

                }
                else 
                {
                    town = _searchTown.ToString();
                }
                ModuleConfiguration.ModuleTitle = town + " Condos For Sale";
                GetSeoValues(town.ToString(), "");


                List<FlexMLSInfo> items;
                FlexMLSController controller = new FlexMLSController();

                items = controller.FlexMLS_Search_Condo_By_Town(town.ToString());

                //bind the data
                GridView1.DataSource = items;
                GridView1.DataBind();



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void LoadSettings()
        {

            try
            {


                if (Settings["FlexMLSModule"] != null)
                {
                    _FlexMLSPage = Settings["FlexMLSModule"].ToString();

                }
                if (Settings["DefaultTown"] != null)
                {
                    _searchTown = Settings["DefaultTown"].ToString();

                }




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //StringBuilder _SearchCriteria = new StringBuilder();
                //_SearchCriteria.Capacity = 500;
                string townname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Town"));
                string complex = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Complex"));

                string condoCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Description"));

                string _pageName = complex.ToString().Replace(" ", "_").ToString().Replace("/","~").ToString() + ".aspx";
                //string _pageName = DataBinder.Eval(e.Row.DataItem, "Town").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString().Replace("'", "^").ToString() + "_Condos.aspx";

                HyperLink eLink = (HyperLink)e.Row.FindControl("Hyperlink2");


                string vLink = "";
                vLink = "/tabid/" + _FlexMLSPage.ToString() + "/pg/List/Type/COND/Town/" + townname.ToString() + "/Complex/" + condoCode.ToString() + "/" + _pageName.ToString();

                eLink.Text = DataBinder.Eval(e.Row.DataItem, "Complex").ToString() + " Condominium";
                eLink.NavigateUrl = vLink.ToString();


                // Retrieve the Hyperlink control in the current DataListItem.
                HyperLink hlItemCount = (HyperLink)e.Row.FindControl("HyperlinkItemCount");
                string _pageName2 = DataBinder.Eval(e.Row.DataItem, "Complex").ToString() + "_Cape_Cod_Condos.aspx";
                    
     
                string vLink2 = "";
                vLink2 = "/tabid/" + _FlexMLSPage.ToString() + "/pg/List/Type/COND/Town/" + townname.ToString() + "/Complex/" + condoCode.ToString() + "/" + _pageName.ToString();
                
                hlItemCount.NavigateUrl = vLink2.ToString();

                HttpUtility.UrlEncode("");


            }

        }

        public void GetSeoValues(string _town, string _complex)
        {

            try
            {
                if (_complex.ToString().Length > 0)
                {
                    DotNetNuke.Framework.CDefault GIBSpage = (DotNetNuke.Framework.CDefault)this.Page;
                    GIBSpage.Title = _complex.ToString() + " " + _town.ToString() + " Cape Cod Condos";
                    GIBSpage.KeyWords = _town.ToString() + ", " + _complex.ToString() + ", " + _town.ToString() + " Condos, " + GIBSpage.KeyWords.ToString();
                    GIBSpage.Description = _complex.ToString() + " " + _town.ToString() + " condos. " + GIBSpage.Description.ToString();   
                    
                    GIBSpage.Author = "Joseph M Aucoin, GIBS";
                }


                else
                {
                    DotNetNuke.Framework.CDefault GIBSpage = (DotNetNuke.Framework.CDefault)this.Page;
                    GIBSpage.Title = _town.ToString() + " Condos";
                    GIBSpage.KeyWords = _town.ToString() + ", " + _complex.ToString() + ", " + _town.ToString() + " Condos, " + GIBSpage.KeyWords.ToString();
                    GIBSpage.Description = _complex.ToString() + " " + _town.ToString() + " condos. " + GIBSpage.Description.ToString();   
                    
                    GIBSpage.Author = "Joseph M Aucoin, GIBS";
                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void LoadTowns()
        {

            try
            {

                List<FlexMLSInfo> items;
                FlexMLSController controller = new FlexMLSController();

                items = controller.FlexMLS_Search_Condo_TownList();

                //bind the data
                RepeaterTowns.DataSource = items;
                RepeaterTowns.DataBind();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        protected void RepeaterTowns_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {


            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HyperLink hp = (HyperLink)e.Item.FindControl("HyperLink1");

                    string townname = DataBinder.Eval(e.Item.DataItem, "Town").ToString();
                    string _pageName = DataBinder.Eval(e.Item.DataItem, "Town").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + "_Condos.aspx";

                    string vLink = Globals.NavigateURL("View", "Town", townname.ToString());
                    vLink = vLink.ToString().Replace("ctl/View/", "");
                    vLink = vLink.ToString().Replace("Default.aspx", _pageName.ToString());
                    hp.Text = DataBinder.Eval(e.Item.DataItem, "Town").ToString();
                    hp.NavigateUrl = vLink.ToString();


                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // No requirement to implement code here
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Prevents the GridView from going into EDIT MODE (textboxes)
            e.Cancel = true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Delete")
                {

                    //int ID = Convert.ToInt32(e.CommandArgument);
                    //FlexMLS_FavoritesController controller = new FlexMLS_FavoritesController();
                    //controller.FlexMLS_Favorites_Delete(ID);

                    //LoadGrid();

                }

                if (e.CommandName == "Edit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    //   FillIncomeExpenseEdit(ieID);


                }




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        #region IActionable Members

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                //actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                //    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                //     true, false);

                return actions;
            }
        }

        #endregion


        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

    }
}