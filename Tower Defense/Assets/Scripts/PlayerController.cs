using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public int Gold { get; set; }

    [field: SerializeField]
    public TextMeshProUGUI InfoLabel { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InfoLabel.text = "Click Build to Place a Turret";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
