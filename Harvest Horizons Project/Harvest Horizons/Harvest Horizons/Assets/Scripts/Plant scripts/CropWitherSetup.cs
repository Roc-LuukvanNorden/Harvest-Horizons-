using UnityEngine;

public class CropWitherSetup : MonoBehaviour
{
    [SerializeField]
    private int daysUntilWither = 2;



    private void Start()
    {
        WitheringLogic wither =
            GetComponent<WitheringLogic>();


        if (wither != null)
        {
            wither.SetDaysUntilWither(
                daysUntilWither
            );
        }
    }
}
