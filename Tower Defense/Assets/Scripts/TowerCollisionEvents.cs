using UnityEngine;
using UnityEngine.Events;

public class TowerCollisionEvents : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent<EnemyAttack> OnEnemyHit;
   
   void OnTriggerEnter(Collider other)
   {
    EnemyAttack attackingEnemy = other.GetComponentInParent<EnemyAttack>();
    if (attackingEnemy == null)
    {
        return; // we didn't hit an attacking enemy
    }

    OnEnemyHit.Invoke(attackingEnemy);
    Debug.Log(other);
   }
}
