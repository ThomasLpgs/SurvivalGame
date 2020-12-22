using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int p_health)
    {
        slider.maxValue = p_health;
        slider.value = p_health;
    }

    public void SetHealth(int p_health)
    {
        slider.value = p_health;
    }

}
