using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {
    private string CurentSM;
    private string NextScene;
    private void Awake()
    {
        
        // NextScene = "Cat_2";
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadifMenu();
        }
    }
    public void LoadifDead()
    {
        Debug.Log("LOAD");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadifFinal()
    {
        CurentSM = SceneManager.GetActiveScene().name;
        if (CurentSM == "Battle1") { NextScene = "Battle2"; }
        if (CurentSM == "Battle2") { NextScene = "Battle3"; }
        if (CurentSM == "Battle3") { NextScene = "Battle4"; }
        if (CurentSM == "Battle4") { NextScene = "Battle5"; }
        SceneManager.LoadScene(NextScene);
    }

    public void LoadifMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void TimeStrop()
    {
        Time.timeScale = 0;
    }
    public void TimePlay()
    {
        Time.timeScale = 1;
    }

}
