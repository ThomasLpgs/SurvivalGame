using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        Debug.Log("Overrrr");
        if (Input.GetMouseButtonDown(0)){
            // Whatever you want it to do.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
