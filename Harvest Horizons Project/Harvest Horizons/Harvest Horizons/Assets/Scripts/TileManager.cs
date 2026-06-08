using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap InteractableGround;
    [SerializeField] private Tile HiddenInteractableTile;
    [SerializeField] private Tile DirtTile;
    [SerializeField] private Vector3Int[] interactablePositions;

    void Start()
    {
        foreach (Vector3Int pos in interactablePositions)
        {
            InteractableGround.SetTile(pos, HiddenInteractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = InteractableGround.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "Interactable")
            {
                return true;
            }
        }
        return false;
    }

    public void TillGround(Vector3Int position)
    {
        if (IsInteractable(position))
        {
            InteractableGround.SetTile(position, DirtTile);
        }
    }
    public Vector3Int GetTilePosition(Vector3 worldPosition)
    {
        return InteractableGround.WorldToCell(worldPosition);
    }

    public void PlantCrop(Vector3Int position, GameObject cropPrefab)
    {
        if (IsDirt(position))
        {
            Vector3 worldPos = InteractableGround.CellToWorld(position);
            worldPos += new Vector3(0.5f, 0.5f, 0f);
            Instantiate(cropPrefab, worldPos, Quaternion.identity);
        }
    }

    public bool IsDirt(Vector3Int position)
    {
        TileBase tile = InteractableGround.GetTile(position);
        return tile != null && tile == DirtTile;
    }
}
