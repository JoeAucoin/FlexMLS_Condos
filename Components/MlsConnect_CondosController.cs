using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.Modules.FlexMLS_Condos.Components
{
    public class FlexMLS_CondosController : IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the FlexMLS_CondosInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<FlexMLS_CondosInfo> GetFlexMLS_Condoss(int moduleId)
        {
            return CBO.FillCollection<FlexMLS_CondosInfo>(DataProvider.Instance().GetFlexMLS_Condoss(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public FlexMLS_CondosInfo GetFlexMLS_Condos(int moduleId, int itemId)
        {
            return (FlexMLS_CondosInfo)CBO.FillObject(DataProvider.Instance().GetFlexMLS_Condos(moduleId, itemId), typeof(FlexMLS_CondosInfo));
        }


        /// <summary>
        /// Adds a new FlexMLS_CondosInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddFlexMLS_Condos(FlexMLS_CondosInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddFlexMLS_Condos(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateFlexMLS_Condos(FlexMLS_CondosInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateFlexMLS_Condos(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteFlexMLS_Condos(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteFlexMLS_Condos(moduleId, itemId);
        }


        #endregion




        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            List<FlexMLS_CondosInfo> infos = GetFlexMLS_Condoss(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<FlexMLS_Condoss>");
                foreach (FlexMLS_CondosInfo info in infos)
                {
                    sb.Append("<FlexMLS_Condos>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</FlexMLS_Condos>");
                }
                sb.Append("</FlexMLS_Condoss>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "FlexMLS_Condoss");

            foreach (XmlNode info in infos.SelectNodes("FlexMLS_Condos"))
            {
                FlexMLS_CondosInfo FlexMLS_CondosInfo = new FlexMLS_CondosInfo();
                FlexMLS_CondosInfo.ModuleId = ModuleID;
                FlexMLS_CondosInfo.Content = info.SelectSingleNode("content").InnerText;
                FlexMLS_CondosInfo.CreatedByUser = UserID;

                AddFlexMLS_Condos(FlexMLS_CondosInfo);
            }
        }

        #endregion
    }
}
