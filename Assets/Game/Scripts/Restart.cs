using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    public Player player;
    public GameObject menuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //menuUI.SetActive(true);
        }
    }
}
