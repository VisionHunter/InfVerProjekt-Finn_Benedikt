using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        List<string> options = new List<string>();
    }

    public void SetVolume (float vol)
    {
        audioMixer.SetFloat("Volume", vol);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
