using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button openStatus;
    public Button openInventory;

    // Start is called before the first frame update
    void Start()
    {
        openInventory.onClick.AddListener(() => UIManager.Instance.OpenInventory());
        openStatus.onClick.AddListener(() => UIManager.Instance.OpenStatus());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init()
    {
        gameObject.SetActive(true);
    }
}
