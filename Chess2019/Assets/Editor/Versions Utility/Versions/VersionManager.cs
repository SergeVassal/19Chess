using System;
using UnityEngine;

namespace VersionsUtility
{
    public class VersionManager
    {
        private VersionName currentVersionName;
        private SubversionName currentSubversionName;
        private PlatformName currentPlatformName;

        private VersionsConfiguration currentVersionsConfiguration;
        private VersionsConfiguration prodVersionConfiguration;
        private VersionsConfiguration devVersionConfiguration;

        public VersionsConfiguration CurrentVersionsConfiguration
        {
            get { return currentVersionsConfiguration; }            
        }

        public VersionName CurrentVersionName
        {
            get { return currentVersionName; }
            set
            {
                currentVersionName = value;
                OnCurrentVersionChanged();
            }
        }

        public SubversionName CurrentSubversionName
        {
            get { return currentSubversionName; }
            set
            {
                currentSubversionName = value;
                OnCurrentVersionChanged();
            }
        }

        public PlatformName CurrentPlatformName
        {
            get { return currentPlatformName; }
            set
            {
                currentPlatformName = value;
                OnCurrentVersionChanged();
            }
        }
        

        public VersionManager()
        {
            prodVersionConfiguration = new ProdVersionConfiguration().FromFile(true);

            devVersionConfiguration = new DevVersionConfiguration().FromFile(false);

            currentVersionsConfiguration = devVersionConfiguration;
            
        }

        #region [Events]

        public event Action CurrentVersionChanged;

        #endregion


        public Version GetCurrentVersion()
        {            
            return GetVersion(currentVersionName, currentSubversionName, currentPlatformName);
        }

        public Version GetVersion(VersionName versionName, SubversionName subversionName, PlatformName platformName)
        {
            
            if (subversionName == SubversionName.Dev)
            {
                currentVersionsConfiguration = devVersionConfiguration;                
            }
            else
            {
                currentVersionsConfiguration = prodVersionConfiguration;
            }
            foreach (Version version in currentVersionsConfiguration.Versions)
            {
                Debug.Log(version.SubversionName);
            }
                

            foreach (Version version in currentVersionsConfiguration.Versions)
            {
                if (version.VersionName.Equals(versionName))
                {
                    if (version.SubversionName.Equals(subversionName))
                    {
                        if (version.PlatformName.Equals(platformName))
                        {
                            return version;
                        }
                    }
                }
            }
            return null;
        }

        public void SetCurrentVersion(VersionName versionName, SubversionName subversionName, PlatformName platformName)
        {
            currentVersionName = versionName;
            currentSubversionName = subversionName;
            currentPlatformName = platformName;
            OnCurrentVersionChanged();
        }

        private void OnCurrentVersionChanged()
        {
            Action handler = CurrentVersionChanged;
            if (handler != null) handler();
        }
    }
}


