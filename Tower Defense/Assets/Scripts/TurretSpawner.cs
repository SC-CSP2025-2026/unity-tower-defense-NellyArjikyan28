using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }
   
    [field: SerializeField]
    public GameObject TurretPrefab { get; private set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClicked.AddListener(SpawnTurret);
        }
    }

    public void SpawnTurret(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            return; // don't spawn a turret if it's already occupied
        }
        if (CanSpawn(tileController))
        {
            GameObject newTurret = Instantiate(TurretPrefab);
            newTurret.transform.position = tileController.transform.position;
            tileController.IsOccupied = true;
            Controller.Gold -= 50;
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClicked.RemoveListener(SpawnTurret);
        }
    }

    public bool CanSpawn(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            return false;
        }

        if (Controller.Gold < 50)
        {
            return false;
        }

        return true;
    }

    public void ShowInfo(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < 50)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough Gold</color>";
        }
        else
        {
            Controller.InfoLabel.text = "50 Gold - Place Turret";
        }
    }
}
