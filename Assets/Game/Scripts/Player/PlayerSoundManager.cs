using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip[] FootStepClips,KickClip,JumpClip;
  
    public AudioSource FootStepsAS;
    public AudioSource KickAS;
    public AudioSource JumpAS;
    
    void Start()
    {
        FootStepsAS = gameObject.AddComponent<AudioSource>();
        KickAS = gameObject.AddComponent<AudioSource>();
        JumpAS = gameObject.AddComponent<AudioSource>();
    }

    void Step(){
        int i = UnityEngine.Random.Range(0,FootStepClips.Length);
        FootStepsAS.clip=FootStepClips[i];
        FootStepsAS.Play();
    }
    
    void Kick(){
        KickAS.clip=KickClip[0];
        KickAS.Play();
    }
    
    void JumpLand(){
        JumpAS.clip=JumpClip[0];
        JumpAS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
