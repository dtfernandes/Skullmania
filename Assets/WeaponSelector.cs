using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{

    [SerializeField]
    private GameObject _sword, _staff, _shield;
    
    public void SelectSword()
    {
        _sword.SetActive(true);
        _staff.SetActive(false);
        _shield.SetActive(false);
    }

    public void SelectStaff()
    {
        _staff.SetActive(true);
        _sword.SetActive(false);
        _shield.SetActive(false);
    }

    public void SelectShield()
    {
        _shield.SetActive(true);
        _staff.SetActive(false);
        _sword.SetActive(false);
    }
}
