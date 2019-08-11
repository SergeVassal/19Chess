using UnityEditor;
using UnityEngine;

namespace VersionsUtility
{
    public class ProdVersionSettingsEditor : IEditorComponent
    {
        #region [Private fields]

        private SerializedObject serializedObject;
        private VersionObject currentVersionObject;
        private Vector2 position;
        private readonly VersionManager versionManager;

        #endregion

        #region [Construction and initialization]

        public ProdVersionSettingsEditor(VersionManager versionManager)
        {
            this.versionManager = versionManager;

            Initialize();
        }

        private void Initialize()
        {
            Version currentVersion = versionManager.GetCurrentVersion();            
            if (currentVersion != null)
            {
                currentVersionObject = (VersionObject)ScriptableObject.CreateInstance(typeof(VersionObject));
                currentVersionObject.AndroidSettings = currentVersion.AndroidSettings;
                currentVersionObject.IOSSettings = currentVersion.IOSSettings;
                currentVersionObject.CommonSettings = currentVersion.CommonSettings;
                serializedObject = new SerializedObject(currentVersionObject);
            }
        }

        #endregion

        #region [IEditorComponent implementation]

        public void OnEnable()
        {
            Initialize();
            versionManager.CurrentVersionChanged += VersionsConfiguration_CurrentVersionChanged;
        }

        public void OnDisable()
        {
            versionManager.CurrentVersionChanged -= VersionsConfiguration_CurrentVersionChanged;
        }

        public void OnComponentGUI()
        {
            if (versionManager.CurrentSubversionName == SubversionName.Dev)
            {
                return;
            }

            var config = serializedObject;

            if (config != null && config.targetObject != null)
            {
                GUI.changed = false;
                config.Update();
                SerializedProperty iterator = config.GetIterator();
                if (iterator != null)
                {
                    bool enterChildren = true;
                    while (iterator.NextVisible(enterChildren))
                    {
                        enterChildren = false;
                        bool hide = false;
                        hide |= (iterator.name == "m_Script");
                        hide |= (versionManager.CurrentPlatformName != PlatformName.iOS && iterator.name == "IOSSettings");
                        hide |= (versionManager.CurrentPlatformName != PlatformName.Android && iterator.name == "AndroidSettings");
                        if (!hide)
                        {
                            EditorGUILayout.PropertyField(iterator, true);
                        }
                    }
                    config.ApplyModifiedProperties();
                }

                EditorGUILayout.Space();
                if (GUILayout.Button("SAVE VERSIONS CONFIGURATION", GUILayout.Height(30)))
                {
                    versionManager.CurrentVersionsConfiguration.Save(true);
                }
            }
            else
            {
                Initialize();
            }

        }

        public string GetComponentName()
        {
            return "PROJECT SETTINGS";
        }

        #endregion

        #region [Event handlers]

        private void VersionsConfiguration_CurrentVersionChanged()
        {
            var version = versionManager.GetCurrentVersion();
            if (version != null)
            {
                currentVersionObject.AndroidSettings = version.AndroidSettings;
                currentVersionObject.IOSSettings = version.IOSSettings;
                currentVersionObject.CommonSettings = version.CommonSettings;
            }
        }

        #endregion
    }
}

