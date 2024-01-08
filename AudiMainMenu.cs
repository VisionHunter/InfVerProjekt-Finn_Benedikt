using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiMainMenu : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    [Header("--- Audio Clip ---")]
    public AudioClip background;
    public AudioClip UIbutton;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }  
}
