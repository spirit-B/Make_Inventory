using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public bool isOpen = false;
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
