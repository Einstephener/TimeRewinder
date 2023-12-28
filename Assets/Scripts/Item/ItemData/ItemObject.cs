using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;
    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }
    public void OnInteract()
    {
        if(item.displayName == "지하실 열쇠")
        {
            ItemManager.Instance.isBasementKeyGet = true;
            Destroy(gameObject);
        }
        if(item.displayName == "영안실 열쇠")
        {
            ItemManager.Instance.isMorgueKeyGet = true;
            Destroy(gameObject);
        }
        if(item.displayName == "정문 열쇠")
        {
            ItemManager.Instance.isMainKeyGet = true;
            Destroy(gameObject);
        }
            
    }
}
