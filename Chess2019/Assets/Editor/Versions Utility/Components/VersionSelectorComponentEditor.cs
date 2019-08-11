using UnityEditor;
using UnityEngine;

namespace VersionsUtility
{
    public class VersionSelectorComponentEditor : IEditorComponent
    {
        #region [Private fields]

        private readonly VersionManager versionManager;
        private VersionName currentVersionName;
        private SubversionName currentSubversionName;
        private PlatformName currentPlatformName;

        #endregion

        #region [Construction and initialization]

        public VersionSelectorComponentEditor(VersionManager versionManager)
        {
            this.versionManager = versionManager;
            this.currentVersionName = versionManager.CurrentVersionName;
            this.currentSubversionName = versionManager.CurrentSubversionName;
            this.currentPlatformName = versionManager.CurrentPlatformName;
        }

        #endregion

        #region [IEditorComponent implementation]

        public void OnDisable()
        {
        }

        public void OnEnable()
        {
        }

        public void OnComponentGUI()
        {
            if (versionManager != null)
            {
                ShowVersionsUI();
            }
        }

        public string GetComponentName()
        {
            return "VERSION SELECTOR";
        }

        #endregion

        #region [Private methods]

        private void ShowVersionsUI()
        {            
            currentVersionName = (VersionName)EditorGUILayout.EnumPopup("Version", currentVersionName);
            currentSubversionName = (SubversionName)EditorGUILayout.EnumPopup("Subversion", currentSubversionName);
            currentPlatformName = (PlatformName)EditorGUILayout.EnumPopup("Platform", currentPlatformName);

            if (GUI.changed)
            {
                versionManager.SetCurrentVersion(currentVersionName, currentSubversionName, currentPlatformName);
            }
        }

        #endregion
    }
}