using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource au;
    public GameObject win;
    public GameObject gameover;
    public GameObject start; public GameObject hi;
    void Start()
    {
        au = new AudioSource();
        au = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (hi.activeSelf) MusicStop();
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
