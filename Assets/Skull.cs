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

    [SerializeField]
    private Animator left, right;

    private Rigidbody rigi;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        rigi = GetComponent<Rigidbody>();
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
        if (other.CompareTag("Kill"))
        {
            Debug.Log("What are teh lel rules");
            sound.Play();
            StartCoroutine("Kill");
            player = null;
            rigi.useGravity = true;
            mesh.enabled = false;
            Destroy(beep);
            left.enabled = true;
            right.enabled = true;
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(sound);
    }
}


