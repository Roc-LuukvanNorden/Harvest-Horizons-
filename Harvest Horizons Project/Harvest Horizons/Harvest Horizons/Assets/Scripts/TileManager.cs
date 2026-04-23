using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap InteractableGround;
    [SerializeField] private Tile HiddenInteractableTile;
    void Start()
    {
        foreach(var position in InteractableGround.cellBounds.allPositionsWithin)
        {
            InteractableGround.SetTile(position,HiddenInteractableTile);

        } 
        
    }
    public bool Isinteractable(Vector3Int position)
    {
        TileBase tile = InteractableGround.GetTile(position);

        if(tile != null)
        {
            if (tile.name == "Interactable")
            {
                return true;
            }
        }
        return false;
    }
   
}
