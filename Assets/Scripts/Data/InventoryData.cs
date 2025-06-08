using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData
{
    public List<ItemData> data = new List<ItemData>(120);

    public InventoryData()
    {
        for (int i = 0; i < 9; i++)
        {
            data.Add(null);
        }
    }
}
