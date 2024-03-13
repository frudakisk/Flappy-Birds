using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private AudioClip backgroundClip;
    private AudioSource sfxSource;
    private AudioSource backgroundSource;
    // Start is called before the first frame update
    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        backgroundSource = GetComponent<AudioSource>();
        backgroundSource.clip = backgroundClip;
        backgroundSource.loop = true;
        backgroundSource.Play();
    }


    public void PlayClip(int clipNumber)
    {
        if(clipNumber >= sfxClips.Length || clipNumber < 0)
        {
            Debug.Log("Clip Number is out of Bounds");
        }
        else
        {
            sfxSource.PlayOneShot(sfxClips[clipNumber], 1.0f);
        }
    }
}
