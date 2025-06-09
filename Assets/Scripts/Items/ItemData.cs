using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    [Header("Item Infomation")]
    public string name;
    public Sprite icon;
    public int attack;
    public int defence;
    public int health;
    public int critical;
}

public class ItemDataList
{
    public ItemData item;
}
