using UnityEngine;
using UnityEngine.UI;
public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Sprite normalSlotSprite;
    [SerializeField] private Sprite selectedSlotSprite;
    [SerializeField] private HotbarSlotUI[] slots;
    void Start()
    {
        UpdateSelection(0);
    }
    public void InitializeItems(ItemData[] items)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Length)
                slots[i].SetItem(items[i]);
        }
    }
    public void UpdateSelection(int selectedIndex)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSelected(i == selectedIndex,
                i == selectedIndex ? selectedSlotSprite : normalSlotSprite);
        }
    }
}
