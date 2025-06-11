using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Experience { get; private set; }
    public int Level { get; private set; }
    public int Attack { get; private set; }
    public int Defence { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }
    public int CurrentExp { get; private set; }

    public List<InventoryItem> equippedItem;

    public Character(string name, string desc, int exp, int level, int atk, int def, int health, int crit)
    {
        Name = name;
        Description = desc;
        Experience = exp;
        Level = level;
        Attack = atk;
        Defence = def;
        Health = health;
        Critical = crit;
        CurrentExp = 9;

        equippedItem = new List<InventoryItem>();
    }

    public void Equip(List<InventoryItem> data)
    {
        foreach (var item in data)
        {
            if (item == null || item.state != ItemState.Equip) continue;

            switch (item.data.Type)
            {
                case ItemType.Weapon:
                    Attack += item.data.attack;
                    break;
                case ItemType.Armor:
                    Defence += item.data.defence;
                    Health += item.data.health;
                    break;
                case ItemType.Accessory:
                    Health += item.data.health;
                    Critical += item.data.critical;
                    break;
            }
            equippedItem.Add(item);
        }
    }

    public void UnEquip(List<InventoryItem> data)
    {
        foreach (var item in data)
        {
            if (item == null || item.state != ItemState.UnEquip) continue;

            switch (item.data.Type)
            {
                case ItemType.Weapon:
                    Attack -= item.data.attack;
                    break;
                case ItemType.Armor:
                    Defence -= item.data.defence;
                    Health -= item.data.health;
                    break;
                case ItemType.Accessory:
                    Health -= item.data.health;
                    Critical -= item.data.critical;
                    break;
            }
            equippedItem.Remove(item);
        }
    }

    public bool IsEquippedType(ItemType type)
    {
        foreach (var item in equippedItem)
        {
            if (item.data.Type == type) return true;
        }
        return false;
    }
}
