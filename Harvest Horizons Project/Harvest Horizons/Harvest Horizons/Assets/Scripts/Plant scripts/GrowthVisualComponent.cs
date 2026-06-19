using UnityEngine;

public class GrowthVisualComponent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private GrowthComponent growth;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        growth = GetComponent<GrowthComponent>();
    }



    private void Start()
    {
        growth.OnGrowthStageChanged += UpdateSprite;


        UpdateSprite(
            growth.GetGrowthStage()
        );
    }




    private void UpdateSprite(int stage)
    {
        GrowthData data = growth.GetGrowthData();


        if (stage < data.growthSprites.Length)
        {
            spriteRenderer.sprite =
                data.growthSprites[stage];
        }
    }



    private void OnDestroy()
    {
        growth.OnGrowthStageChanged -= UpdateSprite;
    }
}
