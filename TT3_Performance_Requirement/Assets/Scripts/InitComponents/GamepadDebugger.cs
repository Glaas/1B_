using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Helper classes to assign bindings to keypad buttons
public class GamepadDebugger : MonoBehaviour
{
   public bool active = false;
    void Update()
    {
        if (!active) return;
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fire2");
        }
        
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Fire3");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
        
        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("Submit");
        }
        
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Cancel");
        }
    }
}
