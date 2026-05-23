using UnityEditor;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [field: SerializeField]
    public Waypoint Next { get; private set; }

    void OnDrawGizmos()
    {
        if (Next == null)
        {
            return; // quits the method 
        }
        Handles.color = Color.red;
        Handles.DrawLine(transform.position, Next.transform.position, 3f);
    }
}
