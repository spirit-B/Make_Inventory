using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Character Player;
    public InventoryData _inventory;

    public InventoryData InventoryData
    {
        get
        {
            if (_inventory == null)
            {
                _inventory = new InventoryData();
            }

            return _inventory;
        }
    }

    void Start()
    {
        SetData();
    }

    public void SetData()
    {
        UIStatus uiStatus = UIManager.Instance.UIStatus;
        UIMainMenu uiMainMenu = UIManager.Instance.UIMainMenu;
        string desc = "코딩의 노예가 된지 10년짜리 되는 머슴입니다. 오늘도 밤샐일만 남아서 치킨을 시킬지도 모른다는 생각에 배민을 키고 있네요.";
        Player = new Character("Chad", desc, 12, 10, 35, 40, 100, 25);

        uiStatus.attackText.text = Player.Attack.ToString();
        uiStatus.defenceText.text = Player.Defence.ToString();
        uiStatus.healthText.text = Player.Health.ToString();
        uiStatus.criticalText.text = Player.Critical.ToString();

        uiMainMenu.characterName.text = Player.Name;
        uiMainMenu.characterLevel.text = $"Lv {Player.Level}";
        uiMainMenu.characterDesc.text = Player.Description;
        uiMainMenu.characterExp.text = $"{Player.CurrentExp} / {Player.Experience}";
    }
}