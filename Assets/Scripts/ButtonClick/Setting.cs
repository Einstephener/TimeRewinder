using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Button SoundSetting;
    public Button BackBtn;
    public GameObject SoundPannel;
    public GameObject HowToUsePannel;


    public void GotoSoundSetting()
    {
        SoundPannel.SetActive(true);
        HowToUsePannel.SetActive(false);
    }
    public void GotoHowToUsePannel()
    {
        SoundPannel.SetActive(false);
        HowToUsePannel.SetActive(true);
    }


}
