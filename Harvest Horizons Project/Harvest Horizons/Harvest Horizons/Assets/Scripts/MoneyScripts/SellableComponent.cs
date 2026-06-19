using UnityEngine;

public class SellableComponent : MonoBehaviour
{
    [SerializeField] private int sellValue = 5;

    public void Sell()
    {
        MoneyManager.Instance.AddMoney(sellValue);
    }

    public int GetSellValue() => sellValue;
}
