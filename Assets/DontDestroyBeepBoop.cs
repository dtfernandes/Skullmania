using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBeepBoop : MonoBehaviour
{

    private static DontDestroyBeepBoop instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null|| instance == this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);        
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
