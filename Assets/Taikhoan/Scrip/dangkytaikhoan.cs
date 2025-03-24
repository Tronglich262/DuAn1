using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class dangkytaikhoan : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI thongbao;


    public Button chuyendn;
    public GameObject dangky;

    public void dangkybutton()
    {
        StartCoroutine(DangKy());


    }
    private IEnumerator DangKy()
    {
        WWWForm Form = new WWWForm();
        Form.AddField("user", username.text);
        Form.AddField("passwd", password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", Form);
        yield return www.SendWebRequest();
        if (!www.isDone)
        {
            thongbao.text = "Kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;
            switch (get)
            {
                case "exist": thongbao.text = " tài khoản đã tồn tại"; break;
                case "OK": thongbao.text = "Đăng kí thành công"; break;
                case "ERROR": thongbao.text = "Đăng kí không thành công"; break;
                default: thongbao.text = "không kết nối được với sever"; break;
            }
        }
    }
    public void SwitchForm()
    {
        dangky.SetActive(!dangky.activeSelf);
    }
    void Start()
    {
        chuyendn.onClick.AddListener(SwitchForm);
    }
}
