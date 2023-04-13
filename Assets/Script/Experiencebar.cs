using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experiencebar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    public void UpdateExperienceSlider(float current, float target)
    {
        slider.maxValue = target;
        slider.value = current;
    }
    public void SetLevelText(float level)
    {
        levelText.text = "Level: " + level.ToString();
    }
}
