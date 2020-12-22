using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHunger(int p_hunger)
    {
        slider.maxValue = p_hunger;
        slider.value = p_hunger;
    }

    public void SetHunger(float p_hunger)
    {
        slider.value = (int)p_hunger;
    }
}
