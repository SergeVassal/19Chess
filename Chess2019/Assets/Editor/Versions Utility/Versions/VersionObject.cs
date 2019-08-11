using UnityEngine;

namespace VersionsUtility
{
    public class VersionObject : ScriptableObject
    {
        public CommonSettings CommonSettings;
        public AndroidSettings AndroidSettings;
        public IOSSettings IOSSettings;
    }
}
