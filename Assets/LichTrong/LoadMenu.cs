using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    void Update()
    {
        // khi bấm vào màn hình bất kì thì sẽ load sang scene khác
        if (Input.GetMouseButtonDown(0)) // Kiểm tra nếu nút chuột trái được nhấn
        {
            SceneManager.LoadScene("Dangky_dangnhap"); // Thay thế "NextScene" bằng tên scene bạn muốn chuyển tới
        }
    }
}
