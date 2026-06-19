using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public static event System.Action<int> OnNewDay;
    public static event System.Action OnDayStart;
    public static event System.Action OnNightStart;

    private int currentDay = 1;
  
    private float timer = 0f;

  

    [SerializeField] private Image nightOverlay;
    [SerializeField] private float morningDuration = 30f;   
    [SerializeField] private float middayDuration = 60f;   
    [SerializeField] private float eveningDuration = 30f;   
    [SerializeField] private float nightDuration = 40f;    

    private enum TimeOfDay { Morning, Midday, Evening, Night }
    private TimeOfDay currentTime = TimeOfDay.Morning;
    private TileManager tileManager;

    void Start()
    {
        tileManager = FindFirstObjectByType<TileManager>();
        nightOverlay = GameObject.Find("Night overlay").GetComponent<Image>();
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentTime)
        {
            case TimeOfDay.Morning:
                float morningAlpha = Mathf.Lerp(0.6f, 0f, timer / morningDuration);
                nightOverlay.color = new Color(0f, 0f, 0.1f, morningAlpha);
                if (timer >= morningDuration)
                {
                    timer = 0f;
                    currentTime = TimeOfDay.Midday;
                    OnDayStart?.Invoke();
                }
                break;

            case TimeOfDay.Midday:
                nightOverlay.color = new Color(0f, 0f, 0.1f, 0f);
                if (timer >= middayDuration)
                {
                    timer = 0f;
                    currentTime = TimeOfDay.Evening;
                }
                break;

            case TimeOfDay.Evening:
                float eveningAlpha = Mathf.Lerp(0f, 0.6f, timer / eveningDuration);
                nightOverlay.color = new Color(0f, 0f, 0.1f, eveningAlpha);
                if (timer >= eveningDuration)
                {
                    timer = 0f;
                    currentTime = TimeOfDay.Night;
                    OnNightStart?.Invoke();
                }
                break;

            case TimeOfDay.Night:
                nightOverlay.color = new Color(0f, 0f, 0.1f, 0.6f);
                if (timer >= nightDuration)
                {
                    timer = 0f;
                    currentTime = TimeOfDay.Morning;
                    currentDay++;
                    tileManager.DryAllTiles();
                    OnNewDay?.Invoke(currentDay);
                    OnDayStart?.Invoke();
                }
                break;
        }
    }
    public int GetCurrentDay() => currentDay;
    public bool IsDay() => currentTime == TimeOfDay.Midday || currentTime == TimeOfDay.Morning;
}
