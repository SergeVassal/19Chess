using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace VersionsUtility
{
    public class VersionsConfiguration : SerializableConfiguration<VersionsConfiguration>
    {
        #region [Events]

        public event Action CurrentVersionChanged;

        #endregion

        #region [Properties]

        public Version[] Versions
        {
            get;
            set;
        }


        #endregion

        #region [Construction and initialization]

        public VersionsConfiguration()
        {
            Versions = new[] { new Version() };
        }

        #endregion
        

        public VersionsConfiguration FromFile(bool isProd)
        {
            VersionsConfiguration versionsConfigurations;
            string path;
            if (isProd)
            {
                path = GetProdFilePath();
            }
            else
            {
                path = GetDevFilePath();
            }
            
            if (File.Exists(path))
            {
                var configData = File.ReadAllText(path);                
                versionsConfigurations = Deserialize(configData);                
            }
            else
            {
                versionsConfigurations = new DevVersionConfiguration();
                if (isProd)
                {
                    versionsConfigurations.Save(true);
                }
                else
                {
                    versionsConfigurations.Save(false);
                }
                
            }
            return versionsConfigurations;
        }

        public void Save(bool isProd)
        {
            string filePath;
            if (isProd)
            {
                filePath = GetProdFilePath();
            }
            else
            {
                filePath = GetDevFilePath();
            }
            
            var encoding = new UTF8Encoding();

            try
            {
                var serializedConfig = SerializeWithIndentedFormatting();
                File.WriteAllText(filePath, serializedConfig, encoding);
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error writing configuration file to {0}.", filePath), e);
            }

            AssetDatabase.Refresh();
        }

        protected string GetProdFilePath()
        {
            try
            {
                return Application.dataPath + "/Editor/Versions Utility/prod_versions_config.txt";
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error writing configuration file."), e);
            }
        }

        protected string GetDevFilePath()
        {
            try
            {
                return Application.dataPath + "/Editor/Versions Utility/dev_versions_config.txt";
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error writing configuration file."), e);
            }
        }

    }
}