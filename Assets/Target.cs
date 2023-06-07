using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float width, height;
    
    public float Width => width;
    public float Height => height;

    [SerializeField]
    private GameObject[] lives;

    private int livesNumb = 3;

    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private Spawner spawner;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skull"))
        {
            livesNumb--;
            lives[livesNumb].SetActive(false);

            if(livesNumb == 0)
            {
                Die();  
            }
        }
    }

    private void Die()
    {
        gameOver.SetActive(true);
        spawner.Stop();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0.1f));
    }
}
