using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Text attstamina;
 

    public void SetStamina(float p_stamina)
    {
        attstamina.text = p_stamina.ToString();
    }
}
