using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus status;
    [SerializeField] private UIInventory inventory;

    [SerializeField] private Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.Init();
        status.Init();
        inventory.Init();
        backButton.onClick.AddListener(() => CloseNowOpen());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenInventory()
    {
        mainMenu.gameObject.SetActive(false);
        inventory.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void OpenStatus()
    {
        mainMenu.gameObject.SetActive(false);
        status.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void CloseNowOpen()
    {
        if (inventory.gameObject.activeInHierarchy)
        {
            mainMenu.gameObject.SetActive(true);
            inventory.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
        }
        else if (status.gameObject.activeInHierarchy)
        {
            mainMenu.gameObject.SetActive(true);
            status.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
        }
    }
}
