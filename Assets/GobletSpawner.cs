using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gobletSpawner;
    [SerializeField]
    private GameObject gobletPREFAB;


    [SerializeField]
    private bool _fibonnaci;
    private int _amount = 1, _prevAmount = 1;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnGoblet();
        }
    }

    public void SpawnGoblet()
    {
        int a = _fibonnaci ? _amount : 1;
        for (int i = 0; i < a; i++)
        {
            Instantiate(gobletPREFAB, gobletSpawner.transform.position, Quaternion.identity);
        }

        if (_fibonnaci) 
        {
            int prev = _amount;
            _amount += _prevAmount;
            _prevAmount = prev;
        }
    }
}
