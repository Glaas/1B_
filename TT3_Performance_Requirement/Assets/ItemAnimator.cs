using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimator : MonoBehaviour
{
    public float oscillationSpeed = 1f;
    public float oscillationDistance = 0.5f;

    private Vector3 startPosition;
    private void Start() {
        
        startPosition = transform.position;
    }
    void Update()
    {
        transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance, 0);
    }
}
