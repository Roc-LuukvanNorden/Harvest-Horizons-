using UnityEngine;

public class TilePlantComponent : MonoBehaviour
{
    private TileManager tileManager;



    private void Awake()
    {
        tileManager =
            FindFirstObjectByType<TileManager>();
    }




    public void RemoveTile()
    {
        Vector3Int tilePosition =
            tileManager.GetTilePosition(
                transform.position
            );


        tileManager.RemovePlantedTile(
            tilePosition
        );
    }
}
