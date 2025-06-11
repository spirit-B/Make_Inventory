using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem item;
    public Image icon;
    public Image equippedIcon;

    private float lastClickTime;
    private float doubleClickThreshold = 0.3f;  // 더블 클릭 시 두번째 클릭 시간을 감지할 변수

    public Action<InventoryItem> OnDoubleClickItem;

    public void SetItem()
    {
        if (item == null || item.data == null)
        {
            RefreshUI();
            return;
        }

        icon.sprite = item.data.icon;
        icon.gameObject.SetActive(true);
        if (item != null)
        {
            equippedIcon.gameObject.SetActive(item.state == ItemState.Equip);
        }
    }

    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
        if (item != null)
        {
            equippedIcon.gameObject.SetActive(item.state == ItemState.UnEquip);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastClickTime < doubleClickThreshold)
        {
            if (item != null)
            {
                OnDoubleClickItem?.Invoke(item);
            }
        }

        lastClickTime = Time.time;
    }
}
