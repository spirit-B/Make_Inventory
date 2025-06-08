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
}
