using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 1f;
    [field: SerializeField]
    public Waypoint Target { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance <= Mathf.Epsilon) 
        {
            if (Target.Next == null)
            {
                return;
            }
            Target = Target.Next;
            transform.LookAt(Target.transform);
        }
    }
}
