using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InventoryItem
{
    public ItemData data;
    public ItemState state;

    public InventoryItem(ItemData item)
    {
        data = item;
        state = ItemState.UnEquip;
    }
}
public class InventoryData
{
    public List<InventoryItem> data = new List<InventoryItem>(120);
    public event UnityAction OnChangedInventory;

    public InventoryData()
    {
        for (int i = 0; i < 9; i++)
        {
            data.Add(null);
        }
    }

    public void AddItem(ItemData item)
    {
        InventoryItem newItem = new InventoryItem(item);

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i] == null)
            {
                data[i] = newItem;
                OnChangedInventory?.Invoke();
                return;
            }
        }

        if (data.Count < 120)
        {
            data.Add(newItem);
            OnChangedInventory?.Invoke();
        }
        else
        {
            Debug.LogWarning("인벤토리 최대치를 초과했습니다.");
        }
    }
}
