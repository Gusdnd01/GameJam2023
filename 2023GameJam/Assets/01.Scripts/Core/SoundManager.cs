using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] AudioClip[] bgmClips;
    [SerializeField] AudioClip[] sfxClips;

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource sfx;
    
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    string sliderName = "";

    public void ChangeSliderValues(string name){
        sliderName =name;
        switch(sliderName){
            case "master":
                masterMixer.SetFloat("Master", masterSlider.value);
                break;
            case "bgm":
                masterMixer.SetFloat("BGM", bgmSlider.value);
                break;
            case "sfx":
                masterMixer.SetFloat("SFX", sfxSlider.value);
                break;
            default:
                break;
        }
    }

    public void BGMPlay(int index){
        bgm.clip = bgmClips[index];
        bgm.Play();
    }

    public void SFXPlay(int index){
        sfx.clip = sfxClips[index];
        sfx.Play();
    }
}
