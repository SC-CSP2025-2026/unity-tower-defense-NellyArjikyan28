using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 2f;

    [field: SerializeField]
    public float Damage { get; private set; } = 1f;

    [field: SerializeField]
    public Transform Target { get; set; }

    void Update()
    {
        if (Target == null)
        {
            Object.Destroy(gameObject);
            return; // quit the method
        }

        transform.LookAt(Target.transform);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance <= Mathf.Epsilon)
        {
            Health healthComponent = Target.GetComponentInParent<Health>();
            if (healthComponent !=null)
            {
                healthComponent.ApplyHit(this);
            }
            Object.Destroy(gameObject);
        }
    }
}
