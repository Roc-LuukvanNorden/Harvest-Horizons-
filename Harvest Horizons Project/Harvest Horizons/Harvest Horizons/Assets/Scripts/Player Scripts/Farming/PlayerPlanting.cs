using UnityEngine;

public class PlayerPlanting : MonoBehaviour
{
    private TileManager tileManager;
    private KeyboardInputs keyboardInputs;
    private Hotbar hotbar;

    public void Initialize(TileManager tileManager, KeyboardInputs keyboardInputs, Hotbar hotbar)
    {
        this.tileManager = tileManager;
        this.keyboardInputs = keyboardInputs;
        this.hotbar = hotbar;
    }

    void Update()
    {
        HandlePlanting();
    }

    private void HandlePlanting()
    {
        if (keyboardInputs == null) return;
        if (!keyboardInputs.GetInteract()) return;
        ItemData selectedItem = hotbar.GetSelectedItem();
        if (selectedItem == null || selectedItem.itemType != ItemType.Seed) return;
        Vector3Int tilePos = tileManager.GetTilePosition(transform.position);
        if (tileManager.IsDirt(tilePos) || tileManager.IsWetDirt(tilePos))
            tileManager.PlantCrop(tilePos, selectedItem.cropPrefab);
        TutorialManager.Instance.NextStep(5); // planted crop
    }
}
