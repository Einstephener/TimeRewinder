using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMainScene : MonoBehaviour
{
    [SerializeField] private TMP_Text LodingTxt;
    [SerializeField] private GameObject StartButton;
    public void ClickStartBtn()
    {
        StartButton.SetActive(false);
        LodingTxt.gameObject.SetActive(true);
        SceneManager.LoadScene("Show");
    }
}
    