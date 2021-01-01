using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     private AudioClip[] WolfStepClips,WolfGrowlClip;
    public AudioSource WolfStepsAS;
    public AudioSource WolfGrowlAS;
    void Start()
    {
        WolfStepsAS = gameObject.AddComponent<AudioSource>();
        WolfGrowlAS = gameObject.AddComponent<AudioSource>();
    }

    void WolfStep(){
           int i = UnityEngine.Random.Range(0,WolfStepClips.Length);
        WolfStepsAS.clip=WolfStepClips[i];
        WolfStepsAS.Play();
    }

    void WolfGrowl(){
           int i = UnityEngine.Random.Range(0,WolfGrowlClip.Length);
        WolfGrowlAS.clip=WolfGrowlClip[i];
        WolfGrowlAS.Play();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
