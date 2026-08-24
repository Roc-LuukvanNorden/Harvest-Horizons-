using UnityEngine;

public class CropGrowthTimer : MonoBehaviour
{
    private IGrowable growable;
    private GrowthData growthData;

    private void Start()
    {
        growable = GetComponent<IGrowable>();

        growthData = GetComponent<GrowthComponent>().GetGrowthData();

        InvokeRepeating(
            nameof(GrowCrop),
            growthData.growthInterval,
            growthData.growthInterval
        );
    }

    private void GrowCrop()
    {
        if (growable.IsFullyGrown())
        {
            CancelInvoke(nameof(GrowCrop));
            return;
        }

        growable.Grow();
    }
}
