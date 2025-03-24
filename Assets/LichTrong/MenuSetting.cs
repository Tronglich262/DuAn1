using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSetting : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public void characterslect()
    {
        SceneManager.LoadScene(0);
    }
    public void Setting()
    {
        SceneManager.LoadScene(6);
    }

    public void Extras()
    {
        SceneManager.LoadScene(4);
    }
    public void Exit()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(8);

    }
    public void login()
    {
        SceneManager.LoadScene(2);

    }
}


