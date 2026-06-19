using System;
using UnityEngine;

public class GrowthComponent : MonoBehaviour, IGrowable
{
    [SerializeField]
    private GrowthData growthData;


    private int currentStage;


    public event Action<int> OnGrowthStageChanged;



    private void Start()
    {
        InvokeRepeating(
            nameof(Grow),
            growthData.growthInterval,
            growthData.growthInterval
        );
    }



    public void Grow()
    {
        if (IsFullyGrown())
        {
            CancelInvoke(nameof(Grow));
            return;
        }


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
