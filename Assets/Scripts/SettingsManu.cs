using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Audio;

public class SettingsManu : MonoBehaviour
{
    public AudioMixer MixerVol;
    public void SetVolume(float Vol)
        {
            Debug.Log(Vol);
            MixerVol.SetFloat("Volume", Vol);
        }

    public void GrahpicSettings(int qualityNum)
    {
        QualitySettings.SetQualityLevel(qualityNum);
    }
}