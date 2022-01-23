using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int _coins;
    public bool hasFireballs;
    public bool hasGroundStomp;

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


    }
    private void Start()
    {
        _coins = 0;
        hasFireballs = false;
        hasGroundStomp = false;
    }
    private void TakeDamage()
    {
        Debug.Log("Player took damage");
        if (hasFireballs || hasGroundStomp)
        {
            hasFireballs = false;
            hasGroundStomp = false;
            return;
        }
        


    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        UIManager.instance.UpdateCoinsText();
    }
}
