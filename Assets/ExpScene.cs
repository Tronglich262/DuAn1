using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpScene : MonoBehaviour
{
    public Slider fillBar;
    public TextMeshProUGUI valuesText;

    public int currentExp = 0;
    private int level = 1;
    private int expToNextLevel = 100;
    private int baseExpIncrease = 500;

    void Start()
    {
        if (fillBar == null) Debug.LogError("fillBar chưa được gán!");
        if (valuesText == null) Debug.LogError("valuesText chưa được gán!");

        // Đảm bảo Slider có đúng min/max value
        fillBar.minValue = 0;
        fillBar.maxValue = 1;

        InvokeRepeating(nameof(UpdateExpUI), 1f, 1f); // Cập nhật UI mỗi giây để kiểm tra
    }

    public void GainExp(int amount)
    {
        Debug.Log($"ExpScene: {gameObject.name} nhận {amount} EXP"); // Kiểm tra đúng object
        currentExp += amount;

        while (currentExp >= expToNextLevel)
        {
            LevelUp();
        }

        UpdateExpUI();
    }


    private void LevelUp()
    {
        currentExp -= expToNextLevel;
        level++;
        expToNextLevel += baseExpIncrease;
    }

    void UpdateExpUI()
    {
        Debug.Log($"UpdateExpUI: {currentExp}/{expToNextLevel}, fillBar = {fillBar.value}");

        if (fillBar != null)
        {
            fillBar.value = (float)currentExp / expToNextLevel;
            Debug.Log($"fillBar.value cập nhật thành: {fillBar.value}");
        }

        if (valuesText != null)
            valuesText.text = $"LV {level}: {currentExp}/{expToNextLevel}";
    }

}