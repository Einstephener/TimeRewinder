using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainDoor : MonoBehaviour
{
    public TMP_Text WarningTxt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (ItemManager.Instance.isMainKeyGet)
            {
                SceneManager.LoadScene("EndingScene");
            }
            else
            {
                WarningTxt.gameObject.SetActive(true);
                WarningTxt.text = "정문 열쇠가 필요합니다.";
            }
        }
    }

}
