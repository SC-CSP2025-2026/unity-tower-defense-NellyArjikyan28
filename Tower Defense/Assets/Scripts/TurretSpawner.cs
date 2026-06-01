using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }
    [field: SerializeField]
    public GameObject TurretPrefab { get; private set; }

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
        GameObject newTurret = Instantiate(TurretPrefab);
        newTurret.transform.position = tileController.transform.position;
        tileController.IsOccupied = true;
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClicked.RemoveListener(SpawnTurret);
        }
    }
}
