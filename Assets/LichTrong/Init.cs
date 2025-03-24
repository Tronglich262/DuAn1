using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public static Character player;
    [SerializeField] private GameObject[] characterPrefabs; // Thêm biến này

    void Start()
    {
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter", "");
        if (string.IsNullOrEmpty(selectedCharacterName))
        {
            Debug.LogError("Lỗi: Không tìm thấy nhân vật đã chọn!");
            return;
        }

        // Tìm Prefab nhân vật
        GameObject selectedCharacter = FindCharacterPrefab(selectedCharacterName);
        if (selectedCharacter == null)
        {
            Debug.LogError("Lỗi: Không tìm thấy Prefab của nhân vật " + selectedCharacterName);
            return;
        }

        // Instantiate nhân vật
        GameObject playerObject = Instantiate(selectedCharacter, transform.position, Quaternion.identity);
        playerObject.name = "player";
    }

    // Tìm Prefab nhân vật theo tên
    GameObject FindCharacterPrefab(string name)
    {
        foreach (GameObject prefab in characterPrefabs)
        {
            if (prefab.name == name)
            {
                return prefab;
            }
        }
        return null;
    }
}