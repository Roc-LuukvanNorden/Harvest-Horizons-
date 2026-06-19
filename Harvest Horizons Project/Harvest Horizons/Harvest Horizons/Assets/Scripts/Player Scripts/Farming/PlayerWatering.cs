using UnityEngine;

public class PlayerWatering : MonoBehaviour
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
        HandleWatering();
    }

    private void HandleWatering()
    {
        if (keyboardInputs == null) return;
        if (!keyboardInputs.GetInteract()) return;
        ItemData selectedItem = hotbar.GetSelectedItem();
        if (selectedItem == null || selectedItem.itemType != ItemType.WateringCan) return;
        Vector3Int tilePos = tileManager.GetTilePosition(transform.position);
        if (tileManager.IsDirt(tilePos) || tileManager.IsWetDirt(tilePos))
            WaterTile(tilePos);
       
    }

    private void WaterTile(Vector3Int tilePos)
    {
        tileManager.WaterTile(tilePos);
        Collider2D[] hits = Physics2D.OverlapCircleAll(tileManager.GetWorldPosition(tilePos), 0.4f);
        TutorialManager.Instance.NextStep(6); // watered crop
        foreach (Collider2D hit in hits)
        {
            WitheringLogic wither = hit.GetComponent<WitheringLogic>();
            if (wither != null) wither.Water();
        }
    }
}