using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepScript : MonoBehaviour
{

    private AudioSource source;
    [SerializeField] private AudioClip[] grassFootstep;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Footstep()
    {
        if(!source.isPlaying)
        {
            int i = Random.Range(0, grassFootstep.Length);
            AudioClip clip = grassFootstep[i];
            source.volume = 0.5f;
            source.PlayOneShot(clip);
            grassFootstep[i] = grassFootstep[0];
            grassFootstep[0] = clip;
        }

        
    }
}

