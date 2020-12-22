using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hunger : MonoBehaviour
{
    public Text atthunger;
 

    public void SetHunger(float p_hunger)
    {
        atthunger.text = p_hunger.ToString();
    }
}
