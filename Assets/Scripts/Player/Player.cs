using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] private int level;
    [SerializeField] private int attack;
    [SerializeField] private int defence;
    [SerializeField] private int health;
    [SerializeField] private int critical;


    public int Level { get => level; private set { level = value; } }
    public int Attack { get => attack; private set { attack = value; } }
    public int Defence { get => defence; private set { defence = value; } }
    public int Health { get => health; private set { health = value; } }
    public int Critical { get => critical; private set { critical = value; } }


    [field: Header("Player Info")]
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Experience { get; private set; }

    [Header("Player Info Text")]
    private TextMeshProUGUI levelText;
    private TextMeshProUGUI attackText;
    private TextMeshProUGUI defenceText;
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI criticalText;

    public void AppliedItem(ItemData item)
    {
        Attack += item.attack;
        Defence += item.defence;
        Health += item.health;
        Critical += item.critical;

        attackText.text = Attack.ToString();
        defenceText.text = Defence.ToString();
        healthText.text = Health.ToString();
        criticalText.text = Critical.ToString();
    }

    public void RemovedItem(ItemData item)
    {
        Attack -= item.attack;
        Defence -= item.defence;
        Health -= item.health;
        Critical -= item.critical;

        attackText.text = Attack.ToString();
        defenceText.text = Defence.ToString();
        healthText.text = Health.ToString();
        criticalText.text = Critical.ToString();
    }
}
