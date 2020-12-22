using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(int p_stamina)
    {
        slider.maxValue = p_stamina;
        slider.value = p_stamina;
    }

    public void SetStamina(float p_stamina)
    {
        slider.value = (int)p_stamina;
    }

}
