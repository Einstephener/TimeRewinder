using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPlay : MonoBehaviour
{
    public static SoundPlay instance;
    public AudioClip OpenDoorClip;
    public AudioSource AudioSource;

    public AudioMixer MasterMixer;
    public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Master"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Master");
            MasterSlider.value = savedVolume;
            SetVolume("Master", savedVolume);
        }
        if (PlayerPrefs.HasKey("BGM"))
        {
            float savedVolume = PlayerPrefs.GetFloat("BGM");
            BGMSlider.value = savedVolume;
            SetVolume("BGM", savedVolume);
        }
        if (PlayerPrefs.HasKey("SFX"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SFX");
            SFXSlider.value = savedVolume;
            SetVolume("SFX", savedVolume);
        }


    }

    public void MasterControl()
    {
        float currentVolume = MasterSlider.value;
        PlayerPrefs.SetFloat("Master", currentVolume);

        // 전체 볼륨 설정
        SetVolume("Master", currentVolume);
    }
    public void BGMControl()
    {
        float currentVolume = BGMSlider.value;
        PlayerPrefs.SetFloat("BGM", currentVolume);

        // 배경 볼륨 설정
        SetVolume("BGM", currentVolume);
    }
    public void SFXControl()
    {
        float currentVolume = SFXSlider.value;
        PlayerPrefs.SetFloat("SFX", currentVolume);

        // 효과음 볼륨 설정
        SetVolume("SFX", currentVolume);
    }
    private void SetVolume(string name,float volume)
    {
        if (volume == -40f)
        {
            MasterMixer.SetFloat(name, -80);
        }
        else
        {
            MasterMixer.SetFloat(name, volume);
        }
    }
    void Update()
    {
        PlayerPrefs.GetFloat("Master", MasterSlider.value);
        PlayerPrefs.GetFloat("BGM", BGMSlider.value);
        PlayerPrefs.GetFloat("SFX", SFXSlider.value);

        MasterControl();
        SFXControl();
        BGMControl();
    }
}
