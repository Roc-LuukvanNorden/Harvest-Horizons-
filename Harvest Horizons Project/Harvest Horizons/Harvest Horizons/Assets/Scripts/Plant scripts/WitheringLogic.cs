using UnityEngine;

public class WitheringLogic : MonoBehaviour
{
    private int daysUntilWither = 2;
    private int daysWithoutWater = 0;
    private bool isWatered = false;
    private SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        DayManager.OnNewDay += HandleNewDay;
    }

    void OnDisable()
    {
        DayManager.OnNewDay -= HandleNewDay;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDaysUntilWither(int days)
    {
        daysUntilWither = days;
    }

    private void HandleNewDay(int day)
    {
        if (isWatered)
        {
            isWatered = false;
            daysWithoutWater = 0;
        }
        else
        {
            daysWithoutWater++;
            Debug.Log("Days without water: " + daysWithoutWater);
            if (daysWithoutWater >= daysUntilWither)
            {
                Wither();
            }
        }
    }

    public void Water()
    {
        isWatered = true;
        daysWithoutWater = 0;
    }

    private void Wither()
    {
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
    }
}

