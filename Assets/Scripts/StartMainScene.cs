using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMainScene : MonoBehaviour
{
    public void ClickStartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
