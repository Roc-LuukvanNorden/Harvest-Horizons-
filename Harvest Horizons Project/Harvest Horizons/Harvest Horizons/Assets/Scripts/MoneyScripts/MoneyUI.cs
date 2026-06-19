using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    void OnEnable()
    {
        MoneyManager.OnMoneyChanged += UpdateMoneyText;
    }

    void OnDisable()
    {
        MoneyManager.OnMoneyChanged -= UpdateMoneyText;
    }

    private void UpdateMoneyText(int amount)
    {
        moneyText.text = "$" + amount + "/1000" ;
    }
}