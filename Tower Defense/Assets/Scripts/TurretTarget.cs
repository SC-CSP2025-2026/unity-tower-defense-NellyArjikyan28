using UnityEngine;

public class TurretTarget : MonoBehaviour
{
    [field: SerializeField]
    public AreaOfEngagement AoE { get; private set; }

    [field: SerializeField]
    public GameObject Model { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AoE.Targets.Count != 0)
        {
            Model.transform.LookAt(AoE.Targets[0].transform);
        }
        
    }
}
