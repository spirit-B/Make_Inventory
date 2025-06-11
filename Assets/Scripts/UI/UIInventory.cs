using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private ItemData[] itemList;

    public List<UISlot> slots;
    public Transform slotPanel;
    public GameObject slotsPrefab;

    public TextMeshProUGUI inventoryCount;
    public TextMeshProUGUI sameTypeWarningText;
    public TextMeshProUGUI noItemWarningText;

    private InventoryData inventoryData;
    private int initSlotCount = 9;
    private int maxSlotCount = 120;

    public bool isOpen = false;

    private Coroutine warningCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CreatItem();
        }
    }

    public void InitInventoryUI()
    {
        slots = new List<UISlot>();

        for (int i = 0; i < initSlotCount; i++)
        {
            GameObject slotObj = Instantiate(slotsPrefab, slotPanel);
            UISlot slot = slotObj.GetComponent<UISlot>();

            slots.Add(slot);
        }

        inventoryData = GameManager.Instance.InventoryData;
        inventoryData.OnChangedInventory += UpdateUI;
        gameObject.SetActive(isOpen);

        InitDoubleClickEvent();
    }

    private void CreatItem()
    {
        if (itemList == null || itemList.Length == 0)
        {
            Debug.LogWarning("ItemList가 비어있습니다. 아이템을 추가하세요.");
            return;
        }

        int randomIdx = Random.Range(0, itemList.Length);

        inventoryData.AddItem(itemList[randomIdx]);
    }

    private void UpdateUI()
    {
        while (slots.Count < inventoryData.data.Count)
        {
            // 기본 생성 되어있는 9칸 슬롯 외에 슬롯을 더 추가하기
            for (int i = 0; i < 9 && slots.Count < maxSlotCount; i++)
            {
                GameObject slotObj = Instantiate(slotsPrefab, slotPanel);
                UISlot slot = slotObj.GetComponent<UISlot>();

                slot.OnDoubleClickItem += HandleDoubleClick;

                slots.Add(slot);
            }
        }


        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventoryData.data.Count)
            {
                var data = inventoryData.data[i];
                if (data != null)
                {
                    slots[i].item = data;
                    slots[i].SetItem();
                }
                else
                {
                    slots[i].RefreshUI();
                }
            }
            else
            {
                slots[i].RefreshUI();
            }
        }

        int hasItemCount = 0;

        foreach (UISlot slot in slots)
        {
            if (slot.item != null)
            {
                hasItemCount++;
            }
        }

        inventoryCount.text = $"Inventory   {hasItemCount} / {maxSlotCount}";
    }

    // 인벤토리에서 처음 아이템의 아이콘을 클릭했을 때
    private void InitDoubleClickEvent()
    {
        foreach (var slot in slots)
        {
            slot.OnDoubleClickItem += HandleDoubleClick;
        }
    }

    // 아이템 아이콘을 더블클릭 했을 때 행동
    private void HandleDoubleClick(InventoryItem item)
    {
        var player = GameManager.Instance.Player;

        // 인벤토리의 빈 칸을 더블 클릭 시
        if (item == null || item.data == null)
        {
            Debug.Log("장착할 아이템이 없습니다.");
            ShowWarning(noItemWarningText);
            return;
        }

        // 아이템의 장착 여부에 따라 아이템을 장착하거나 해제함
        if (item.state == ItemState.UnEquip)
        {
            if (player.IsEquippedType(item.data.Type))
            {
                Debug.Log("이미 같은 타입의 아이템을 장착했습니다.");
                ShowWarning(sameTypeWarningText);
                return;
            }
            item.state = ItemState.Equip;
            player.Equip(new List<InventoryItem> { item });
        }
        else
        {
            item.state = ItemState.UnEquip;
            player.UnEquip(new List<InventoryItem> { item });
        }

        UIManager.Instance.UIStatus.UpdateUI(player);   // 스탯 UI갱신
        UpdateUI();
    }

    // 중복 타입 아이템 장착 시 띄워줄 경고문에 사용될 메서드
    private void ShowWarning(TextMeshProUGUI warningText)
    {
        if (warningCoroutine != null)
        {
            StopCoroutine(warningCoroutine);
        }

        warningCoroutine = StartCoroutine(FadeOutWarningText(warningText));
    }

    // 경고문을 페이드아웃 시키기 위한 메서드
    private IEnumerator FadeOutWarningText(TextMeshProUGUI warningText)
    {
        warningText.gameObject.SetActive(true);
        float duration = 2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(2f, 0f, elapsed / duration);
            warningText.color = new Color(warningText.color.r, warningText.color.g, warningText.color.b, alpha);
            yield return null;
        }

        warningText.gameObject.SetActive(false);
        warningCoroutine = null;
    }
}
