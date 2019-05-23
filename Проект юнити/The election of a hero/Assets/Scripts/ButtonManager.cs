using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public LoadScene load;

    public void Awake()
    {
        load = new LoadScene();
    }
    public void Start()
    {
        load = new LoadScene();
    }
    public void Button()
    {
        load.LoadifFinal();
    }

    public void MainMenu()
    {
        load.LoadifMenu();
    }

}
