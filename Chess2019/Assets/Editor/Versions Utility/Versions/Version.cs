using System;
using UnityEditor;

namespace VersionsUtility
{
    public enum VersionName
    {
        Main
    }

    public enum SubversionName
    {
        Dev,
        Prod
    }

    public enum PlatformName
    {
        iOS,
        Android
    }

    [Serializable]
    public class Version
    {
        public VersionName VersionName;
        public SubversionName SubversionName;
        public PlatformName PlatformName;
        public CommonSettings CommonSettings;
        public AndroidSettings AndroidSettings;
        public IOSSettings IOSSettings;
    }

    [Serializable]
    public class CommonSettings
    {
        public string CompanyName;
        public string ProductName;
        public string AppVersion;
        public Identification Identification;

        public string DefaultIcon;

        public string StoreLink;
    }

    [Serializable]
    public class Identification
    {
        public string BundleIdentifier;
        public string BundleVersion;
        public string ShortBundleVersion;
    }


    [Serializable]
    public class AndroidSettings
    {
        public string GooglePlayAppId;   
    }

    [Serializable]
    public class IOSSettings
    {
        public string AppStoreId;
    }    
}
