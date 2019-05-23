using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound2 : MonoBehaviour {

    public AudioSource au;
    public GameObject win;
    public GameObject gameover;
    public GameObject start;
    void Start()
    {
        au = new AudioSource();
        au = GetComponent<AudioSource>();
    }
    void Update()
    {
       
    }
    public void MusicPlay()
    {
        au.Play();
    }
    public void MusicStop()
    {
        au.Stop();
    }
}
