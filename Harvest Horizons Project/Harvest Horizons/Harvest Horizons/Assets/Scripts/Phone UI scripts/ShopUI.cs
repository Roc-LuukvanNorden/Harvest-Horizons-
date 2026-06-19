using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopItem[] shopItems;
    [SerializeField] private ShopSlotUI[] slots;

    void Awake()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            slots[i].Initialize(this, shopItems[i], i);
        }
    }
    public void BuyItem(int index)
    {
        ShopItem item = shopItems[index];
        if (MoneyManager.Instance.SpendMoney(item.price))
        {
            Debug.Log("Bought: " + item.itemData.itemName);
            TutorialManager.Instance.NextStep(2); // bought a seed
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
}

[System.Serializable]
public class ShopItem
{
    public ItemData itemData;
    public int price;
}

