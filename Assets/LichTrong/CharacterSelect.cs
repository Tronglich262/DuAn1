using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private int index;
    [SerializeField] GameObject[] characters;
    [SerializeField] TextMeshProUGUI Charactername;

    [SerializeField] GameObject[] characterPrefabs;
    public static GameObject selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;    
    }
    public void OnPlayBtnClick()
    {
        if (selectedCharacter == null)
        {
            Debug.LogError("Lỗi: Chưa chọn nhân vật!");
            return;
        }

        // Lưu tên nhân vật vào PlayerPrefs để dùng ở màn 2
        PlayerPrefs.SetString("SelectedCharacter", selectedCharacter.name);
        PlayerPrefs.Save();

        SceneManager.LoadScene(10);  // Chuyển sang màn 1
    }

    public void OnPrevBtnClick()
    {
        if(index > 0) 
        {
            index--;
        }
        SelectCharacter();
    }
    public void OnNextBtnClick()
    {
        if(index  < characters.Length - 1) 
        {
            index++;
        }
        SelectCharacter();
    }
    public void SelectCharacter()
    {
        for(int i  = 0; i < characters.Length; i++)
        {
            if(i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                characters[i].GetComponent<Animator>().enabled = true;
                selectedCharacter = characterPrefabs[i];
                Charactername.text = characterPrefabs[i].name;
            }
            else
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.black;
                characters[i].GetComponent<Animator>().enabled = false;
            }
        }

    }
}
