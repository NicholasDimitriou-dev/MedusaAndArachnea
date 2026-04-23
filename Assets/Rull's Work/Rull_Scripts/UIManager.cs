using UnityEngine;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateCoins(int current, int max)
    {
        coinText.text = "Coins: " + current + " / " + max;
    }

    public void UpdateTimer(float time)
    {
        time = Mathf.Max(0, time);
        timerText.text = "Time: " + Mathf.CeilToInt(time).ToString();
    }

}
