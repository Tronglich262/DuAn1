using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    void Update()
    {
        // khi bấm vào màn hình bất kì thì sẽ load sang scene khác
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Menu"); 
        }
    }
}
