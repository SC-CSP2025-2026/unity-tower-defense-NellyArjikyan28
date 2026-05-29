using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsOccupied { get; private set; } = false;

    [field: SerializeField]
    public UnityEvent<TileController> OnCursorEnter;

    [field: SerializeField]
    public UnityEvent<TileController> OnCursorExit;

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }

    public void NotifyCursorExit()
    {
        OnCursorExit.Invoke(this);
    }
}
