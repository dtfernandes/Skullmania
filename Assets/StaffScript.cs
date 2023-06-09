using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _pSpawnPoint, _pTargetPointd;
    [SerializeField]
    private ProjectileScript _projectilePREFAB;

    private WaitForSeconds cooldown;

    private bool inCooldown;

    [SerializeField]
    private float _speed;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShootStaff();
        }    
    }

    public void ShootStaff()
    {
        if(inCooldown) return;



        ProjectileScript pS =
            Instantiate(_projectilePREFAB, _pSpawnPoint.transform.position, Quaternion.identity);
        pS.ShootDir = _pTargetPointd.transform.position - _pSpawnPoint.transform.position;
        pS.Speed = _speed;
        StartCoroutine(Cooldown());
        inCooldown = true;
    }

    IEnumerator Cooldown()
    {
        yield return cooldown;
        inCooldown = false;
    }
}
