using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private ItemData[] itemList;

    public List<UISlot> slots;
    public Transform slotPanel;
    public GameObject slotsPrefab;

    public TextMeshProUGUI inventoryCount;

    private InventoryData inventoryData;
    private int initSlotCount = 9;
    private int maxSlotCount = 120;
    private int hasItemCount = 0;

    public bool isOpen = false;

    private void Update()
    {
        CreatItem();
    }

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
        inventoryData.OnChangedInventory += UpdateUI;
        gameObject.SetActive(isOpen);
    }

    private void CreatItem()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (itemList == null || itemList.Length == 0)
            {
                Debug.LogWarning("ItemList가 비어있습니다. 아이템을 추가하세요.");
                return;
            }

            int randomIdx = Random.Range(0, itemList.Length);

            inventoryData.AddItem(itemList[randomIdx]);
            Debug.Log("아이템이 정상적으로 생성되었습니다.");
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            var data = inventoryData.data[i];
            if (data.item != null)
            {
                slots[i].item = data.item;
                slots[i].SetItem();
            }
            else
            {
                slots[i].RefreshUI();
            }
        }
    }
}
