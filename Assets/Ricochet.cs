using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet : MonoBehaviour
{

    private GameObject obj;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
            obj = other.gameObject;



        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

        }
    }
}
