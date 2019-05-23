using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuConttrol : MonoBehaviour {

    public void PlayPressed()
    {
       
        SceneManager.LoadScene("Battle1");
    }

    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }

}
