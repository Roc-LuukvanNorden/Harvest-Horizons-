using System.Collections;
using UnityEngine;

public class PlayerTilling : MonoBehaviour
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
        HandleTilling();
    }

    private void HandleTilling()
    {
        if (keyboardInputs == null) return;
        if (!keyboardInputs.GetInteract()) return;
        ItemData selectedItem = hotbar.GetSelectedItem();
        if (selectedItem == null || selectedItem.itemType != ItemType.Hoe) return;
        Vector3Int tilePos = tileManager.GetTilePosition(transform.position);
        if (tileManager.IsInteractable(tilePos))
            StartCoroutine(TillAndWait(tilePos));
        TutorialManager.Instance.NextStep(4); // tilled ground
    }

    private IEnumerator TillAndWait(Vector3Int tilePos)
    {
        tileManager.TillGround(tilePos);
        yield return null;
    }
}
