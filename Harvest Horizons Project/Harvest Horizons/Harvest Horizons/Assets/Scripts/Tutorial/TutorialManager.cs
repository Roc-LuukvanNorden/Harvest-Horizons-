using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject tutorialPanel;

    private int currentStep = 0;

    private string[] tutorialSteps = new string[]
    {
        "Press Tab to open your phone!",
        "Press the shop icon to open the shop!",
        "Buy some seeds! But be carefull not to spend all your money.",
        "Close the shop and press Tab to close your phone!",
        "Select your hoe and press Space to till the ground!",
        "Select your seeds and plant them on the dirt!",
        "Select your watering can and water your crops!",
        "Wait for your crops to grow, then press E to harvest and sell your crops. This is to make money and repay your debt."
    };

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateTutorialText();
    }

    public void NextStep(int requiredStep)
    {
        if (currentStep != requiredStep) return;
        currentStep++;
        if (currentStep >= tutorialSteps.Length)
        {
            StartCoroutine(HideTutorialAfterDelay());
            return;
        }
        UpdateTutorialText();
    }

    private IEnumerator HideTutorialAfterDelay()
    {
        tutorialText.text = "You're all set, happy farming!";
        yield return new WaitForSeconds(10f);
        tutorialPanel.SetActive(false);
    }
    private void UpdateTutorialText()
    {
        tutorialText.text = tutorialSteps[currentStep];
    }

    public int GetCurrentStep() => currentStep;
}
