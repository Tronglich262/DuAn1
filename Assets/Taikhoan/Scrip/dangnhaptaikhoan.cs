using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dangnhaptaikhoan : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI thongbao;
    //chuyển đăng nhập với đăng kí
    public Button chuyendk;
    public GameObject dangnhap;



    public void DangNhapButton()
    {
        StartCoroutine(DangNhap());


    }
    IEnumerator DangNhap()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", username.text);
        form.AddField("passwd", password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return www.SendWebRequest();
        if (!www.isDone)
        {
            thongbao.text = "Kết nối không thành công";

        }
        else
        {
            string get = www.downloadHandler.text;
            if (get == "empty")
            {
                thongbao.text = "Các thông tin không được để trống";
            }
            else if (get == "" || get == null)
            {
                thongbao.text = "Tài khoản hoặc mật khẩu không chính xác";
            }
            else if (get.Contains("Lỗi"))
            {
                thongbao.text = "Không kết nối được tới server";
            }
            else
            {
                thongbao.text = "Đăng nhập thành công";
                PlayerPrefs.SetString("token", get);
                Debug.Log(get);
                SceneManager.LoadScene(2);
            }
        }
    }
    void Start()
    {
        chuyendk.onClick.AddListener(SwitchForm);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchForm()
    {
        dangnhap.SetActive(!dangnhap.activeSelf);
    }
}
