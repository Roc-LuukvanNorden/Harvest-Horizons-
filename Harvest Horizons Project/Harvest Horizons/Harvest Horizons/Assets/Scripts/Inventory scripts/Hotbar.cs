using UnityEngine;

public class Hotbar : MonoBehaviour
{
    [SerializeField] private HotbarUI hotbarUI;
    [SerializeField] private ItemData[] items = new ItemData[5];

    private int selectedSlot = 0;
    void Start()
    {
        hotbarUI.InitializeItems(items);
        hotbarUI.UpdateSelection(selectedSlot);
    }
    void Update()
    {
        HandleScrollWheel();
        HandleNumberKeys();
        hotbarUI.UpdateSelection(selectedSlot);
    }

    private void HandleScrollWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            selectedSlot = (selectedSlot - 1 + items.Length) % items.Length;
        }
        else if (scroll < 0f)
        {
            selectedSlot = (selectedSlot + 1) % items.Length;
        }
    }

    private void HandleNumberKeys()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedSlot = i;
            }
        }
    }

    public ItemData GetSelectedItem()
    {
        return items[selectedSlot];
    }
}
