using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerFarming : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    [SerializeField] private KeyboardInputs keyboardInputs;
    [SerializeField] private GameObject cornPrefab;

    [SerializeField] private Hotbar hotbar;

    void Update()
    {
        if (keyboardInputs.GetInteract())
        {
            ItemData selectedItem = hotbar.GetSelectedItem();
            if (selectedItem == null) return;

            Vector3Int tilePos = tileManager.GetTilePosition(transform.position);

            if (selectedItem.itemType == ItemType.Hoe && tileManager.IsInteractable(tilePos))
            {
                StartCoroutine(TillAndWait(tilePos));
                return;
            }

            if (selectedItem.itemType == ItemType.Seed && tileManager.IsDirt(tilePos))
            {
                tileManager.PlantCrop(tilePos, cornPrefab);
            }
        }
    }

        private IEnumerator TillAndWait(Vector3Int tilePos)
    {
        tileManager.TillGround(tilePos);
        yield return null; 
    }
}
