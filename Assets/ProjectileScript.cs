using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Vector3 ShootDir { get; set; }
    public float Speed { get => _speed; set => _speed = value; }

    [SerializeField]
    private float _speed;

    IEnumerator Die()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ShootDir.normalized * Speed * Time.deltaTime;
    }
}
