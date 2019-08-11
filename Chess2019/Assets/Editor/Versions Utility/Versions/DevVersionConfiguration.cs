using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VersionsUtility
{
    public class DevVersionConfiguration : VersionsConfiguration
    {
        private const string DEVCONFIGPATH = "/Editor/Versions Utility/dev_versions_config.txt";

        protected string GetFilePath()
        {
            try
            {
                return Application.dataPath + DEVCONFIGPATH;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error writing configuration file to {0}.", DEVCONFIGPATH), e);
            }
            
        }
    }

}


