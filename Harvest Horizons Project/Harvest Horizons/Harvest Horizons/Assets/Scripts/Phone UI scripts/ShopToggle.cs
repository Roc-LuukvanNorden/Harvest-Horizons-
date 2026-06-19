using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    public void ToggleShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        if (shopPanel.activeSelf)
            TutorialManager.Instance.NextStep(1); // opened shop
    }
}
