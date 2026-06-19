using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap InteractableGround;
    [SerializeField] private Tile HiddenInteractableTile;
    [SerializeField] private Tile DirtTile;
    [SerializeField] private Vector3Int[] interactablePositions;
    private HashSet<Vector3Int> plantedTiles = new HashSet<Vector3Int>();
    [SerializeField] private Tile WetDirtTile;
    private HashSet<Vector3Int> wetTiles = new HashSet<Vector3Int>();

    public void WaterTile(Vector3Int position)
    {
        if (IsDirt(position) || IsWetDirt(position))
        {
            InteractableGround.SetTile(position, WetDirtTile);
            wetTiles.Add(position);
        }
    }

    public void DryAllTiles()
    {
        foreach (Vector3Int pos in wetTiles)
        {
            InteractableGround.SetTile(pos, DirtTile);
        }
        wetTiles.Clear();
    }
  

    public bool IsWetDirt(Vector3Int position)
    {
        TileBase tile = InteractableGround.GetTile(position);
        return tile != null && tile == WetDirtTile;
    }

    public void DryTile(Vector3Int position)
    {
        if (IsWetDirt(position))
        {
            InteractableGround.SetTile(position, DirtTile);
        }
    }
    public Vector3 GetWorldPosition(Vector3Int position)
    {
        return InteractableGround.CellToWorld(position) + new Vector3(0.5f, 0.5f, 0f);
    }
    public bool IsPlanted(Vector3Int position)
    {
        return plantedTiles.Contains(position);
    }

    public void PlantCrop(Vector3Int position, GameObject cropPrefab)
    {
        if ((IsDirt(position) || IsWetDirt(position)) && !IsPlanted(position))
        {
            Vector3 worldPos = InteractableGround.CellToWorld(position);
            worldPos += new Vector3(0.5f, 0.5f, 0f);
            Instantiate(cropPrefab, worldPos, Quaternion.identity);
            plantedTiles.Add(position);
        }
    }

    public void RemovePlantedTile(Vector3Int position)
    {
        plantedTiles.Remove(position);
    }

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
        return tile != null && tile == HiddenInteractableTile;
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

    
    public bool IsDirt(Vector3Int position)
    {
        TileBase tile = InteractableGround.GetTile(position);
        return tile != null && tile == DirtTile;
    }
}
