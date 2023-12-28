using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public TMP_Text WarningTxt;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(gameObject.tag == "Elevator")
            {
                WarningTxt.text = "엘레베이터는 작동하지 않는다.";
            }
            else if (gameObject.tag == "Door")
            {
                WarningTxt.text = "잠겨있는 듯하다.";
            }
            WarningTxt.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            WarningTxt.gameObject.SetActive(false);
        }
    }
}
