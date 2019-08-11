using UnityEditor;

public static class HeyworksEditorMenu
{
    [MenuItem("Heyworks/Versions/Settings", false, 0)]
    private static void ShowVersionsSettingsWindow()
    {
        VersionsUtility.VersionsEditorWindow.Init();
    }
}