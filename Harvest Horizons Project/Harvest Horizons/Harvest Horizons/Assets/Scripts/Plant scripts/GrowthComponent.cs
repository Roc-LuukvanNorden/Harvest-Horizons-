using System;
using UnityEngine;

public class GrowthComponent : MonoBehaviour, IGrowable
{
    [SerializeField]
    private GrowthData growthData;

    private int currentStage;

    public event Action<int> OnGrowthStageChanged;

    public void Grow()
    {
        if (IsFullyGrown())
            return;

        currentStage++;

        OnGrowthStageChanged?.Invoke(currentStage);
    }

    public bool IsFullyGrown()
    {
        return currentStage >= growthData.GrowthStages - 1;
    }

    public int GetGrowthStage()
    {
        return currentStage;
    }

    public GrowthData GetGrowthData()
    {
        return growthData;
    }
}
