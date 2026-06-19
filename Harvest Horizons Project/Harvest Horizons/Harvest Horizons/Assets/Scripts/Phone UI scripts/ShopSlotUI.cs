using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Button buyButton;
    [SerializeField] private int shopIndex;

    private ShopUI shopUI;

    public void Initialize(ShopUI shop, ShopItem item, int index)
    {
        shopUI = shop;
        shopIndex = index;
        itemIcon.sprite = item.itemData.itemSprite;
        itemName.text = item.itemData.itemName;
        itemPrice.text = "$" + item.price;
        buyButton.onClick.AddListener(() => shopUI.BuyItem(shopIndex));
    }
}
