using System;
using System.Data;
using System.Configuration;
using System.Collections;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace GIBS.Modules.FlexMLS_Condos.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class FlexMLS_CondosSettings : ModuleSettingsBase
    {
       

        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user
        /// </summary>
        /// 

        public string DefaultTown
        {
            get
            {
                if (Settings.Contains("DefaultTown"))
                    return Settings["DefaultTown"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "DefaultTown", value.ToString());
            }
        }


        public string FlexMLSModule
        {
            get
            {
                if (Settings.Contains("FlexMLSModule"))
                    return Settings["FlexMLSModule"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "FlexMLSModule", value.ToString());
            }
        }

        #endregion
    }
}
