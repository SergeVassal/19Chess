namespace VersionsUtility
{
    public interface IEditorComponent
    {
        string GetComponentName();
        void OnEnable();
        void OnComponentGUI();
        void OnDisable();
    }
}