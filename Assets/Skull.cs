using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Target target;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private GameObject beep;

    private MeshRenderer mesh;

    [SerializeField]
    private Animator left, right;

    private Rigidbody rigi;
    bool foundTarget = false;
    Vector3 targetPoint;

    public System.Action onDie;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        target = GameObject.FindObjectOfType<Target>();
        rigi = GetComponent<Rigidbody>();
    }

    public Vector3 FindRandomPoint()
    {
        float randX = Random.Range(target.transform.position.x - target.Width / 2, target.transform.position.x + target.Width / 2);
        float randY = Random.Range(target.transform.position.y - target.Height / 2, target.transform.position.y + target.Height / 2);

        Vector3 returnPoint = new Vector3(randX, randY, target.transform.position.z);
        return returnPoint;
    }

    private void Update()
    {
        if(!foundTarget && target != null)
        {
            //Define point
            targetPoint = FindRandomPoint();
            foundTarget = true;
        }

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed);        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
            Debug.Log("What are teh lel rules");
            sound.Play();
            StartCoroutine("Kill");
            target = null;
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
        onDie?.Invoke();
    }
}


