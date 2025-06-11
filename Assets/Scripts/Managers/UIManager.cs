using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus status;
    [SerializeField] private UIInventory inventory;

    [SerializeField] private Button backButton;

    public UIMainMenu UIMainMenu => mainMenu;
    public UIStatus UIStatus => status;
    public UIInventory UIInventory => inventory;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.Init();
        status.Init();
        inventory.InitInventoryUI();
        backButton.onClick.AddListener(() => CloseNowOpen());
    }

    // 인벤토리 창 열기
    public void OpenInventory()
    {
        mainMenu.gameObject.SetActive(false);
        inventory.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    // 스탯 창 열기
    public void OpenStatus()
    {
        mainMenu.gameObject.SetActive(false);
        status.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    // 열려있는 창을 닫기
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