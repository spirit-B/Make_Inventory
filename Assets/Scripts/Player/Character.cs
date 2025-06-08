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
    }
}
