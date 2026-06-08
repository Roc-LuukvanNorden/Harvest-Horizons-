using UnityEngine;
using UnityEngine.UI;

public class HotbarSlotUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image itemImage;

    public void SetSelected(bool selected, Sprite backgroundSprite)
    {
        backgroundImage.sprite = backgroundSprite;
    }

    public void SetItem(ItemData item)
    {
        if (item != null)
        {
            itemImage.sprite = item.itemSprite;
            itemImage.gameObject.SetActive(true);
        }
        else
        {
            itemImage.gameObject.SetActive(false);
        }
    }
}
