using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public bool isOpen = false;

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI criticalText;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Init()
    {
        gameObject.SetActive(isOpen);
    }

    public void UpdateUI(Character player)
    {
        attackText.text = player.Attack.ToString();
        defenceText.text = player.Defence.ToString();
        healthText.text = player.Health.ToString();
        criticalText.text = player.Critical.ToString();
    }
}
