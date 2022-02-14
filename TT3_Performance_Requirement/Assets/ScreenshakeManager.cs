using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenshakeManager : MonoBehaviour
{

    public static ScreenshakeManager instance;
    CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void ScreenShake(float force)
    {
        impulseSource.GenerateImpulse(force);
    }


}
