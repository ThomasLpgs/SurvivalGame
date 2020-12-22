using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hp : MonoBehaviour
{
    public Text atthp;
 
   

    public void SetHp(float p_hp)
    {
        atthp.text = p_hp.ToString();
    }
}
