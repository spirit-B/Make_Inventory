using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button openStatus;
    public Button openInventory;

    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterLevel;
    public TextMeshProUGUI characterExp;
    public TextMeshProUGUI characterDesc;

    // Start is called before the first frame update
    void Start()
    {
        openInventory.onClick.AddListener(() => UIManager.Instance.OpenInventory());
        openStatus.onClick.AddListener(() => UIManager.Instance.OpenStatus());
    }
    public void Init()
    {
        gameObject.SetActive(true);
    }
}
