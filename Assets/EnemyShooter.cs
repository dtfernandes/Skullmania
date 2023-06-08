using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private ProjectileScript projectilePREFAB;

    private WaitForSeconds wait;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        wait = new WaitForSeconds(2);
        StartCoroutine(ShootTimer());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootTimer()
    {
        while(true)
        {
            yield return wait;
            Shoot();
        }
    }

    public void Shoot()
    {
        ProjectileScript pS =
            Instantiate(projectilePREFAB, transform.position, Quaternion.identity);

        pS.ShootDir = player.transform.position - transform.position;
    }
}
