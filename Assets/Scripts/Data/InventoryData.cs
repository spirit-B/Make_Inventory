using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryData
{
    public List<ItemDataList> data = new List<ItemDataList>(120);
    public event UnityAction OnChangedInventory;

    public InventoryData()
    {
        for (int i = 0; i < 9; i++)
        {
            data.Add(new ItemDataList());
        }
    }

    public void AddItem(ItemData item)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i] != null && data[i].item == null)
            {
                data[i].item = item;
                OnChangedInventory?.Invoke();
                return;
            }
        }
    }
}
