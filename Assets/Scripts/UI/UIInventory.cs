using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UISlot> slots;
    public Transform slotPanel;
    public GameObject slotsPrefab;

    public TextMeshProUGUI inventoryCount;

    private InventoryData inventoryData;
    private int initSlotCount = 9;
    private int maxSlotCount = 120;
    private int hasItemCount = 0;

    public bool isOpen = false;

    public void InitInventoryUI()
    {
        slots = new List<UISlot>();

        for (int i = 0; i < initSlotCount; i++)
        {
            GameObject slotObj = Instantiate(slotsPrefab, slotPanel);
            UISlot slot = slotObj.GetComponent<UISlot>();

            slots.Add(slot);
        }

        foreach (UISlot slot in slots)
        {
            if (slot.item != null)
            {
                hasItemCount++;
            }
        }

        inventoryCount.text = $"Inventory   {hasItemCount} / {maxSlotCount}";

        inventoryData = GameManager.Instance.InventoryData;
        gameObject.SetActive(isOpen);
    }
}
