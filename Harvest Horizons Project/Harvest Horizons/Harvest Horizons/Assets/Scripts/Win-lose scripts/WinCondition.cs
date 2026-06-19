using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int moneyGoal = 1000;

    void OnEnable()
    {
        MoneyManager.OnMoneyChanged += CheckWin;
    }

    void OnDisable()
    {
        MoneyManager.OnMoneyChanged -= CheckWin;
    }

    private void CheckWin(int currentMoney)
    {
        if (currentMoney >= moneyGoal)
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene("Win Scene");
        }
    }
}
