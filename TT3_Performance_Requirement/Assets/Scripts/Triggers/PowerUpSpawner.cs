using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fireballPowerup, groundStompPowerup;
    [SerializeField]
    bool isFireball;


    private void Start()
    {
        InvokeRepeating("CheckIfPowerUpIsHere", 0, 4);
    }
    //Check if there is a power up at this location, and if not, spawn one
    void CheckIfPowerUpIsHere()
    {
        Collider2D[] collidersInViscinity = Physics2D.OverlapCircleAll(transform.position, .2f);
        if (collidersInViscinity.Length <= 0)
        {
            var clone = Instantiate(isFireball ? fireballPowerup : groundStompPowerup, transform.position, Quaternion.identity);
            clone.transform.SetParent(transform);
        }
    }
    //To have visibility on spawners in the level editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}
