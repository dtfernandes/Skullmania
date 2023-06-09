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


            ProjectileScript pS = obj.GetComponent<ProjectileScript>();
            if (pS != null)
            {
                pS.ShootDir = transform.right;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

        }
    }
}
