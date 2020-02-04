using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.Modules.FlexMLS_Condos.Components;
using System.Collections;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;

namespace GIBS.Modules.FlexMLS_Condos
{
    public partial class Settings : FlexMLS_CondosSettings
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    BindModules();


                    if (Settings.Contains("DefaultTown"))
                    {
                        txtDefaultTown.Text = DefaultTown; //Settings["Town"].ToString();


                    }
                    if (Settings.Contains("FlexMLSModule"))
                    {
                        ddlFlexMLSModule.SelectedValue = FlexMLSModule; // Settings["FlexMLSModulePage"].ToString();
                    }


                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        // GET THE DROPDOWN FOR GIBS - MLS Connect MODULES
        private void BindModules()
        {

            DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
            ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "GIBS - FlexMLS");

            foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
            {
                if (!mi.IsDeleted)
                {
                    ListItem objListItem = new ListItem();

                    objListItem.Value = mi.TabID.ToString();    // mi.ModuleID.ToString();
                    objListItem.Text = mi.ModuleTitle.ToString();

                    ddlFlexMLSModule.Items.Add(objListItem);

                }
            }


            ddlFlexMLSModule.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));
        }

        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                
                FlexMLSModule = ddlFlexMLSModule.SelectedValue.ToString();
                DefaultTown = txtDefaultTown.Text.ToString();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}