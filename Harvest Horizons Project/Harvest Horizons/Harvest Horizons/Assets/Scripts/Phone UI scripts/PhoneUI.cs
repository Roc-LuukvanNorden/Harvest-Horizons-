using UnityEngine;

public class PhoneUI : MonoBehaviour
{
    [SerializeField] private GameObject phonePanel;
    [SerializeField] private GameObject phoneButton;
    private bool isOpen = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePhone();
        }
    }

    public void TogglePhone()
    {
        isOpen = !isOpen;
        phonePanel.SetActive(isOpen);
        phoneButton.SetActive(!isOpen);
        Time.timeScale = isOpen ? 0f : 1f;
        if (isOpen)
            TutorialManager.Instance.NextStep(0); // opened phone
        else
            TutorialManager.Instance.NextStep(3); // closed phone
    }
}
