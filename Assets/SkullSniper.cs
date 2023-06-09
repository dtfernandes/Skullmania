using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkullSniper : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float range = 5f;

    private Target target;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private GameObject beep;

    private MeshRenderer mesh;

    [SerializeField]
    private Animator left, right;

    private float originalX;
    private Rigidbody rigi;
    private GameObject player;
    bool foundTarget = false;
    Vector3 targetPoint;
    private float _currentTime;
    private float _nextTimeToShoot;
    [Header("# Between x and y")][SerializeField] private Vector2 _intervalToShoot;
    [SerializeField] GameObject _projectile;

    public System.Action onDie;

    private void Start()
    {
        originalX = transform.position.x;
        mesh = GetComponent<MeshRenderer>();
        target = GameObject.FindObjectOfType<Target>();
        rigi = GetComponent<Rigidbody>();
        _nextTimeToShoot = Random.Range(_intervalToShoot.x, _intervalToShoot.y);
        player = FindObjectOfType<FadeEffect>().gameObject;
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
        _currentTime += Time.deltaTime;
        if (_currentTime >= _nextTimeToShoot)
        {
            Shot();
            _nextTimeToShoot = Random.Range(_intervalToShoot.x, _intervalToShoot.y);
            _currentTime = 0.0f;
        }
        UpdatePos();
    }

    private void UpdatePos()
    {
        float newX = originalX + Mathf.PingPong(Time.time * speed, range * 2) - range;
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    private void Shot()
    {
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        ProjectileScript projScript = projectile.GetComponent<ProjectileScript>();
        projScript.AddTarget(player, new Vector3(0,0.4f,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
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


