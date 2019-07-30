using UnityEngine;

public class DragAndDrop
{
    private State state;
    private GameObject item;
    private Vector2 offset;

    private enum State
    {
        None,
        Drag
    }


    public DragAndDrop()
    {
        Drop();
    }

    public void Action()
    {
        //Debug.Log(state);
        switch (state)
        {
            case State.None:
                if (IsMouseButtonPressed())
                {
                    PickUp();
                }
                break;
            case State.Drag:
                if (IsMouseButtonPressed())
                {
                    Drag();
                }
                else
                {
                    Drop();
                }
                break;
        }
    }

    private bool IsMouseButtonPressed()
    {
        return Input.GetMouseButton(0);
    }

    private void PickUp()
    {
        Vector2 clickPosition = GetClickPosition();
        Transform clickedItem = GetItemAt(clickPosition);
        if (clickedItem == null)
        {
            return;
        }
        state = State.Drag;
        item = clickedItem.gameObject;
        offset = (Vector2)clickedItem.position - clickPosition;
    }
    
    private Vector2 GetClickPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private Transform GetItemAt(Vector2 position)
    {
        RaycastHit2D[] figures = Physics2D.RaycastAll(position, position, 0.5f);
        if (figures.Length == 0)
        {
            return null;
        }

        return figures[0].transform;
    }

    private void Drag()
    {
        item.transform.position = GetClickPosition()+offset;
    }

    private void Drop()
    {
        item = null;
        state = State.None;
    }
}