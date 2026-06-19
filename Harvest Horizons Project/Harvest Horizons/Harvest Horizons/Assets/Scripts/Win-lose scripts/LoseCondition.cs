using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    void OnEnable()
    {
        MoneyManager.OnMoneyChanged += CheckLose;
    }

    void OnDisable()
    {
        MoneyManager.OnMoneyChanged -= CheckLose;
    }

    private void CheckLose(int currentMoney)
    {
        if (currentMoney <= 0 && NoCropsLeft())
        {
            Debug.Log("You Lose!");
            SceneManager.LoadScene("Lose Scene");
        }
    }

    private bool NoCropsLeft()
    {
        return FindObjectsByType<GrowthComponent>(
            FindObjectsSortMode.None
        ).Length == 0;
    }
}
