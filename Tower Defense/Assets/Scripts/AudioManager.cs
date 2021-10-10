using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;

    public List<AudioClip> sfxList;
    public AudioSource sfxSource;
    private float startVol;
    public int currSong = 0;

    private void Awake()
    {
        inst = this;
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        inst = this;
    }


}