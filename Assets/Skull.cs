using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private GameObject player;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private GameObject beep;

    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0,1,0), speed);
            //

            //transform.LookAt(-player.transform.position); 
            //transform.eulerAngles += new Vector3(0, 100, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Skull");
        if (other.CompareTag("Kill"))
        {
            Debug.Log("What are teh lel rules");
            sound.Play();
            StartCoroutine("Kill");
            mesh.enabled = false;
            Destroy(beep);
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(sound);
    }
}


