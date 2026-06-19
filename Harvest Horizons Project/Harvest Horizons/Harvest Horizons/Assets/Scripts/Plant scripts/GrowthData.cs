using UnityEngine;

[CreateAssetMenu(
    fileName = "GrowthData",
    menuName = "Farming/Growth Data"
)]
public class GrowthData : ScriptableObject
{
    public Sprite[] growthSprites;

    public float growthInterval = 30f;


    public int GrowthStages
    {
        get
        {
            return growthSprites.Length;
        }
    }
}
