using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class test : MonoBehaviour
{

    public UnityEvent onTrigger;

    private void Update() 
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (InputDevice device in inputDevices)
        {
            bool triggerValue;
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
               onTrigger?.Invoke();
            }
        }
    
            
    }

}
