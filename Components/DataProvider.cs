using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace GIBS.Modules.FlexMLS_Condos.Components
{
    public abstract class DataProvider
    {

        #region common methods

        /// <summary>
        /// var that is returned in the this singleton
        /// pattern
        /// </summary>
        private static DataProvider instance = null;

        /// <summary>
        /// private static cstor that is used to init an
        /// instance of this class as a singleton
        /// </summary>
        static DataProvider()
        {
            instance = (DataProvider)Reflection.CreateObject("data", "GIBS.Modules.FlexMLS_Condos.Components", "");
        }

        /// <summary>
        /// Exposes the singleton object used to access the database with
        /// the conrete dataprovider
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return instance;
        }

        #endregion


        #region Abstract methods

        /* implement the methods that the dataprovider should */

        public abstract IDataReader GetFlexMLS_Condoss(int moduleId);
        public abstract IDataReader GetFlexMLS_Condos(int moduleId, int itemId);
        public abstract void AddFlexMLS_Condos(int moduleId, string content, int userId);
        public abstract void UpdateFlexMLS_Condos(int moduleId, int itemId, string content, int userId);
        public abstract void DeleteFlexMLS_Condos(int moduleId, int itemId);

        #endregion

    }



}
