using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject win;
    public TextMeshProUGUI timerText; // Kết nối với UI Text để hiển thị thời gian
    private float timeRemaining = 60f; // 2 phút

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= 1f;
            if (timerText != null)
                timerText.text = "Time: " + timeRemaining.ToString("F0") + "s";
            yield return new WaitForSeconds(1f);
        }

        if (timeRemaining == 0)
        {
            win.SetActive(true);
            Time.timeScale = 0f;
        }
        Debug.Log("Hết thời gian!");
    }
}