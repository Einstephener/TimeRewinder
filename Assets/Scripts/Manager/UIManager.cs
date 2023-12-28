using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject HowToPlayPanel;
    public GameObject InGamePanel;
    public TMP_Text WarningTxt;

    private void Awake()
    {
        instance = this;
    }

    public void GoToStatue()
    {
        WarningTxt.gameObject.SetActive(true);
        WarningTxt.text = "여신상에서 소리가 들렸다.";
        Invoke("SetOffTxt", 10f);
    }

    private void SetOffTxt()
    {
        WarningTxt.gameObject.SetActive(false);
    }
}
