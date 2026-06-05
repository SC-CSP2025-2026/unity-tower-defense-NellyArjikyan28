using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [field: SerializeField]
    public BuildingData Selected { get; set; }
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }
   
    [field: SerializeField]
    public GameObject TurretPrefab { get; set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
        Controller.InfoLabel.text = "Select a Tile";
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        Controller.InfoLabel.text = "Click Build to Place a Turret";
        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(HandleTileExited);
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
            GameObject newTurret = Instantiate(Selected.BuildingPrefab, Controller.transform);
            newTurret.transform.position = tileController.transform.position;
            tileController.IsOccupied = true;
            Controller.Gold -= Selected.Cost;
            gameObject.SetActive(false); // disable our turret spawner
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(HandleTileExited);
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
            Controller.InfoLabel.text = $"{Selected.Cost} - Place Turret";
        }
    }

    public void HandleTileExited(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }
}
