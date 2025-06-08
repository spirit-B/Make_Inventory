using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            // 이미 인스턴스가 설정되어 있으면 인스턴스 반환
            if (_instance != null)
                return _instance;

            // Scene에서 T 타입을 가진 오브젝트 찾기
            _instance = FindObjectOfType<T>();

            // 위 두 조건이 모드 없다면 새로 생성
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
            }

            return _instance;
        }
    }
}
