using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private Transform target;
   

    

    private void Awaken()
    {
        
        if (!target) target = FindObjectOfType<PlayerScript>().transform;
        


    }
    private void Start()
    {
        transform.position = new Vector3(-0.69F, 0.0F, -10F);
        if (!target) target = FindObjectOfType<PlayerScript>().transform;
    }

    private void Update()
    {
       

        Vector3 pozition = target.position; pozition.z = -10.0F;
        if (pozition.y < 0)
        {
            // Debug.Log(pozition.y);
            pozition.y = 0;
            //  Debug.Log(pozition.y);
        }
        if (pozition.x < -0.69)
        {
            // Debug.Log(pozition.y);
            pozition.x = -0.69F;
            //  Debug.Log(pozition.y);
        }
        if (pozition.x > 0.69)
        {
            // Debug.Log(pozition.y);
            pozition.x = 0.69F;
            //  Debug.Log(pozition.y);
        }

        // pozition.z = -1;
        transform.position = Vector3.Lerp(transform.position, pozition, speed * Time.deltaTime);
    }
}
