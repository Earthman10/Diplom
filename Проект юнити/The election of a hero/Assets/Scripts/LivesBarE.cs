using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBarE : MonoBehaviour {

    private Transform[] hearts = new Transform[5];
    public EnemyL boss;


    private void Awaken()
    {
        boss = FindObjectOfType<EnemyL>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log("Жизни после врага");
            Debug.Log(hearts[i]);
        }
    }
    private void Start()
    {
        boss = FindObjectOfType<EnemyL>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log(hearts[i]);
        }
    }

    public void Refresh2()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
           
            if (i < boss.Lives_b) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
            Debug.Log("Жизни врага восле рефреша");
        }
    }
}
