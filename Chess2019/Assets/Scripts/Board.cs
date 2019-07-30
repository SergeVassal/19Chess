using UnityEngine;

public class Board : MonoBehaviour 
{
    DragAndDrop dragAndDrop=new DragAndDrop();

    private void Update()
    {
        dragAndDrop.Action();
    }
}

