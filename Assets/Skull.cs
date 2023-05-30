using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0,1,0), 0.5f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Skull");
        if (other.CompareTag("Kill"))
        {
            Debug.Log("What are teh rules");
            Destroy(gameObject);
        }
    }
}
