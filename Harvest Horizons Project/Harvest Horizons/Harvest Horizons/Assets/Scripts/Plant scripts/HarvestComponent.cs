using UnityEngine;

public class HarvestComponent : MonoBehaviour, IInteractable
{
    private GrowthComponent growth;



    private void Awake()
    {
        growth = GetComponent<GrowthComponent>();
    }



    public void Interact(GameObject interactor)
    {
        if (!growth.IsFullyGrown())
            return;


        Harvest();
    }



    private void Harvest()
    {
        GetComponent<SellableComponent>()
            ?.Sell();


        GetComponent<TilePlantComponent>()
            ?.RemoveTile();


        Destroy(gameObject);
        TutorialManager.Instance.NextStep(7); // harvested crop
    }




    public string GetInteractionPrompt()
    {
        if (growth.IsFullyGrown())
            return "Harvest";


        return "Growing...";
    }
}
