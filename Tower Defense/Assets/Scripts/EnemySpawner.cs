using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [field: SerializeField]
    public EnemyMovement Enemy { get; private set; }

    [field: SerializeField]
    public Waypoint StartingWaypoint { get; private set; }

    [field: SerializeField]
    public float Delay { get; private set; } = 5f;

    [field: SerializeField]
    public float SpawnsRemaining { get; private set; } = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), Delay, Delay);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        EnemyMovement newEnemy = Object.Instantiate(Enemy);
        newEnemy.Target = StartingWaypoint;
        SpawnsRemaining--; //Spawn -= 1; //SpawnsRemaining = SpawnsRemaining - 1;
        if (SpawnsRemaining == 0)
        {
            CancelInvoke();
        }
    }

    
}
