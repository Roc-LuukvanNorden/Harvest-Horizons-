using UnityEngine;

public class Crop : MonoBehaviour, IGrowable
{
    [SerializeField] protected Sprite[] growthStageSprites;
    [SerializeField] protected float growthInterval = 30f;

    protected int currentStage = 0;
    protected SpriteRenderer spriteRenderer;

    public event System.Action<int> OnGrowthStageChanged;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
        InvokeRepeating(nameof(Grow), growthInterval, growthInterval);
    }

    public void Grow()
    {
        if (!IsFullyGrown())
        {
            currentStage++;
            OnGrowthStageChanged?.Invoke(currentStage);
            UpdateSprite();
        }
        else
        {
            CancelInvoke(nameof(Grow));
        }
    }

    private void UpdateSprite()
    {
        if (growthStageSprites.Length > currentStage)
            spriteRenderer.sprite = growthStageSprites[currentStage];
    }

    public bool IsFullyGrown() => currentStage >= growthStageSprites.Length - 1;
    public int GetGrowthStage() => currentStage;
}
