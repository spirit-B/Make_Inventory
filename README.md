# 유니티 심화 개인 프로젝트 (인벤토리 구현하기)

## 📦 주요 기능

- **인벤토리 UI**  
  - 슬롯 기반 아이템 표시 (최대 120칸)
  - 더블클릭으로 장비 장착 및 해제 가능
  - 랜덤 아이템 생성 기능 (T 키 입력)
  - 아이템 추가 생성 시 동적 슬롯 생성 및 스크롤 기능

- **캐릭터 스탯 시스템**  
  - 장비에 따라 스탯(공격력, 방어력, 체력, 치명타) 변화
  - 장비 장착/해제 시 실시간 스탯 UI 반영

- **UI 관리**  
  - 메인 메뉴, 인벤토리, 스탯 창 전환
  - Back 버튼으로 UI 닫기 및 전환 가능

- **싱글톤 기반 매니저 구조**  
  - `GameManager`, `UIManager` 등 Singleton 패턴 사용
  - 게임 상태 및 UI 상태 중앙 관리

---

## 🧩 구성 요소

### 📁 Scripts

| 파일명              | 설명 |
|-------------------|------|
| `GameManager.cs`  | 게임 데이터 초기화 및 캐릭터 설정 |
| `UIManager.cs`    | UI 전환 및 초기화 처리 |
| `UIInventory.cs`  | 인벤토리 UI 구성 및 랜덤 아이템 생성, 장비 관리 |
| `UIStatus.cs`     | 캐릭터의 스탯 UI 갱신 기능 |
| `UIMainMenu.cs`   | 메인 메뉴 UI, 버튼 이벤트 처리 |
| `InventoryData.cs`| 인벤토리 데이터 및 아이템 추가 로직 |
| `ItemData.cs`     | 아이템 정보 정의 (ScriptableObject 기반) |
| `UISlot.cs`       | 슬롯 UI 및 더블클릭 처리 |
| `Character.cs`    | 캐릭터 정보 및 장비 장착/해제 처리 |
| `Singleton.cs`    | MonoBehaviour 기반 싱글톤 템플릿 |

---

## 🧪 사용 방법

### 1. 인벤토리에서 아이템 생성
- **T 키**를 누르면 `ItemData` 배열 중 하나를 무작위로 생성하여 인벤토리에 추가합니다.
- 아이템 생성 시, 기본 생성되어 있는 인벤토리의 9칸 슬롯을 넘어가면 동적으로 9칸씩 더 생성합니다.

### 2. 아이템 장착/해제
- 아이템 슬롯을 **더블클릭**하면 해당 아이템을 장착하거나 해제합니다.
- 장착 상태는 슬롯의 `equippedIcon` 으로 표시됩니다.

### 3. 캐릭터 스탯 반영
- 장비 장착 시 캐릭터의 공격력, 방어력, 체력, 치명타 수치가 변경되고, UI에도 반영됩니다.

### 4. UI 전환
- 메인 메뉴에서 버튼을 클릭해 인벤토리 또는 스탯 창으로 진입 가능
- UI 전환 시 `UIManager`를 통해 현재 열려 있는 창을 자동 제어

---

## 📸 스크린샷
![image](https://github.com/user-attachments/assets/2df2a31a-829c-4aaa-b599-72598aa22e4b)

![image](https://github.com/user-attachments/assets/17422c6d-a87d-4d4a-8dd0-f987020ff027)

---

## 🔖 향후 개선 아이디어

- 아이템 드래그 & 드롭 기능 추가
- 슬롯 확장 시스템 개선
- 장착 가능한 슬롯 구분 (무기/방어구/악세서리)
- 저장 및 로드 기능 추가

---

## 📃 라이선스
사용한 에셋 라이센스입니다.
<Kyrise's Free 16x16 RPG Icon Pack>
(CC BY 4.0)
https://kyrise.itch.io/kyrises-free-16x16-rpg-icon-pack
![image](https://github.com/user-attachments/assets/6d535511-34a5-4bc0-9050-6294bc73bed4) ![image](https://github.com/user-attachments/assets/3c9e266f-7345-4066-a978-e7a249e5de3f)

