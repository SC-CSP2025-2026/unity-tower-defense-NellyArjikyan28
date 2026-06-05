using UnityEngine;
using UnityEngine.Events;

public class TowerController : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 5f;

    [field: SerializeField]
    public float Damage { get; private set; } = 0f;

    [field: SerializeField]
    public UnityEvent<TowerController> OnDestroyed; 

    public void ApplyHit(EnemyAttack attack)
    {
        Damage += attack.Damage;
        Object.Destroy(attack.gameObject);
        if (Damage >= BaseHealth)
        {
            Object.Destroy(this.gameObject);
            OnDestroyed.Invoke(this);
        }
    }
}
