using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LobbySetup : MonoBehaviour
{
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindObjectOfType<XROrigin>().gameObject;
        _player.GetComponent<DynamicMoveProvider>().enabled = true;
        _player.transform.position = new Vector3(0, 0.125f, 2.93f);
    }


}
