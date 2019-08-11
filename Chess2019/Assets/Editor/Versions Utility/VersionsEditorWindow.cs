using UnityEditor;
using UnityEngine;

namespace VersionsUtility
{
    public class VersionsEditorWindow : EditorWindow
    {
        private static EditorWindow window;
        private IEditorComponent[] editorComponents;
        private Vector2 scrollViewPosition;
        private bool busy;

        public static void CloseWindow()
        {
            if (window != null)
            {
                window.Close();
            }
        }

        public static void Init()
        {
            CloseWindow();
            window = GetWindow(typeof(VersionsEditorWindow), false, "Version settings");
            window.Show();
        }

        protected void OnEnable()
        {
            busy = false;

            VersionManager versionManager = new VersionManager();

            editorComponents = new IEditorComponent[]
                           {
                               new VersionSelectorComponentEditor(versionManager),
                               new DevVersionSettingsEditor(versionManager),
                               new ProdVersionSettingsEditor(versionManager),
                               //new ProjectSettingsImporterEditor(version),
                               //new VersionPrefabsSettingsEditor(prefabs)
                           };

            foreach (var editorComponent in editorComponents)
            {
                editorComponent.OnEnable();
            }
            busy = true;
        }

        protected void OnDisable()
        {
            busy = false;
            if (editorComponents != null)
            {
                foreach (var editorComponent in editorComponents)
                {
                    if (editorComponent != null)
                    {
                        editorComponent.OnDisable();
                    }
                }
            }
        }

        

        public void OnGUI()
        {
            busy &= !EditorApplication.isCompiling;
            busy &= !EditorApplication.isPlayingOrWillChangePlaymode;
            busy &= !EditorApplication.isUpdating;
            busy &= (editorComponents != null && editorComponents.Length > 0);

            EditorGUILayout.BeginVertical();
            scrollViewPosition = EditorGUILayout.BeginScrollView(scrollViewPosition);


            if (busy)
            {
                foreach (var editorComponent in editorComponents)
                {
                    if (editorComponent != null)
                    {
                        EditorGUILayout.Space();

                        
                        editorComponent.OnComponentGUI();
                        
                    }
                }
            }
            else
            {
                EditorGUILayout.HelpBox("UPDATING, PLEASE WAIT", MessageType.Warning, true);
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}