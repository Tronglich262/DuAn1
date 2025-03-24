using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chonmap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void map1()
    {
        SceneManager.LoadScene(1);
    }
    public void map2()
    {
        SceneManager.LoadScene(11);
    }
    public void map3()
    {
        SceneManager.LoadScene(10);
    }
    public void mapreturn()
    {
        SceneManager.LoadScene(0);
    }
}
