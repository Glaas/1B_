using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
    }
   

}
