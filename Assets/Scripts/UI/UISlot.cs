using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData item;
    public Image icon;

    public void SetItem()
    {
        if (item == null)
        {
            RefreshUI();
            return;
        }

        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
    }

    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
    }
}
