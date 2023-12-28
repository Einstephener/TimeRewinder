using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OpenBasement : MonoBehaviour
{
    public GameObject BasementDoor;
    public GameObject MorgueDoor;
    public TMP_Text WarningTxt;

    public Animator BasementAnimator;
    public Animator MorgueAnimator;
    private bool alreadyOpenBasement;
    private bool alreadyOpenMorgue;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (gameObject.CompareTag("Door"))
            {
                if (ItemManager.Instance.isBasementKeyGet)
                {
                    OpenBasementDoor();
                }
                else if (ItemManager.Instance.isMorgueKeyGet)
                {
                    OpenMorgueDoor();
                }
                else
                {
                    WarningTxt.gameObject.SetActive(true);
                    WarningTxt.text = "열쇠가 필요합니다.";
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            WarningTxt.gameObject.SetActive(false);
        }
    }

    private void OpenBasementDoor()
    {
        if(!alreadyOpenBasement)
        {
            BasementAnimator.SetBool("DoorOpen", true);
            audioSource.Play();
            alreadyOpenBasement = true;
            UIManager.instance.GoToStatue();
        }
    }
    private void OpenMorgueDoor()
    {
        if(!alreadyOpenMorgue)
        {
            MorgueAnimator.SetBool("DoorOpen", true);
            audioSource.Play();
            alreadyOpenMorgue = true;
        }
    }

}
