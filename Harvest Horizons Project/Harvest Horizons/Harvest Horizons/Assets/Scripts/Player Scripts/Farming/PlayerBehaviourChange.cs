using UnityEngine;

public class PlayerBehaviourChange : MonoBehaviour
{
    [SerializeField] private Hotbar hotbar;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private KeyboardInputs keyboardInputs;

    private ItemType currentBehaviour = ItemType.None;

    void Update()
    {
        HandleBehaviourSwap();
    }

    private void HandleBehaviourSwap()
    {
        ItemData selectedItem = hotbar.GetSelectedItem();
        if (selectedItem == null) return;
        if (selectedItem.itemType != currentBehaviour)
            SwapBehaviour(selectedItem.itemType);
    }

    private void SwapBehaviour(ItemType newBehaviour)
    {
        RemoveCurrentBehaviour();
        AddNewBehaviour(newBehaviour);
        currentBehaviour = newBehaviour;
    }

    private void RemoveCurrentBehaviour()
    {
        if (GetComponent<PlayerTilling>() != null) Destroy(GetComponent<PlayerTilling>());
        if (GetComponent<PlayerPlanting>() != null) Destroy(GetComponent<PlayerPlanting>());
        if (GetComponent<PlayerWatering>() != null) Destroy(GetComponent<PlayerWatering>());
    }

    private void AddNewBehaviour(ItemType newBehaviour)
    {
        switch (newBehaviour)
        {
            case ItemType.Hoe:
                gameObject.AddComponent<PlayerTilling>().Initialize(tileManager, keyboardInputs, hotbar);
                break;
            case ItemType.Seed:
                gameObject.AddComponent<PlayerPlanting>().Initialize(tileManager, keyboardInputs, hotbar);
                break;
            case ItemType.WateringCan:
                gameObject.AddComponent<PlayerWatering>().Initialize(tileManager, keyboardInputs, hotbar);
                break;
        }
    }
}
