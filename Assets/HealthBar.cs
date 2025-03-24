using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valuesText;

    public void UpdateBar(int currentValues, int maxValues)
    {
        fillBar.fillAmount = (float)currentValues / (float)maxValues;
        valuesText.text = currentValues.ToString() + "/" + maxValues.ToString();
    }
    public void UpdateBar(int value, int maxValue, string text)
    {
        valuesText.text = text;
        fillBar.fillAmount = (float)value / (float)maxValue;
    }
}