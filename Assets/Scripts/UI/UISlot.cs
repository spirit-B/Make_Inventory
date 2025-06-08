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

        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
    }

    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
    }
}
