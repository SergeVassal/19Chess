using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VersionsUtility
{
    public class ProdVersionConfiguration : VersionsConfiguration
    {
        private const string PRODCONFIGPATH = "/Editor/Versions Utility/prod_versions_config.txt";

        protected string GetFilePath()
        {
            try
            {
                return Application.dataPath + PRODCONFIGPATH;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error writing configuration file to {0}.", PRODCONFIGPATH), e);
            }
            
        }
    }
}


