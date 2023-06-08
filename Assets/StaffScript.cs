using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _pSpawnPoint, _pTargetPointd;
    [SerializeField]
    private ProjectileScript _projectilePREFAB;

    // Start is called before the first frame update
    void Start()
    {
        
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
        ProjectileScript pS =
            Instantiate(_projectilePREFAB, _pSpawnPoint.transform.position, Quaternion.identity);
        pS.ShootDir = _pTargetPointd.transform.position - _pSpawnPoint.transform.position;
    }
}
