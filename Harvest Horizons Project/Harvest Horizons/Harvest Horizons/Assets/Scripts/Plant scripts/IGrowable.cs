using UnityEngine;

public interface IGrowable
{
    void Grow();
    bool IsFullyGrown();
    int GetGrowthStage();

}
