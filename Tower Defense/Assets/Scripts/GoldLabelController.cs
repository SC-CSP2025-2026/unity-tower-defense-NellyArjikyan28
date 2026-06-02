using UnityEngine;
using TMPro;

public class GoldLabelController : MonoBehaviour
{
    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI Label { get; private set; }

    // Update is called once per frame
    void Update()
    {
        Label.text = $"Gold: {Controller.Gold}";
    }
}
