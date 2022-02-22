using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void Start()
    {
        //Self destruct after 2 seconds
        Destroy(gameObject, 2f);
    }
    //When colliding with a Destructible object, destroy the fireball
    //And just causes damage to enemies
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<BlobState>())
            {
                other.gameObject.GetComponent<BlobState>().BlobDeath();
                Destroy(gameObject);
            }
            else if (other.gameObject.GetComponent<IcyState>())
            {
                other.gameObject.GetComponent<IcyState>().IcyDeath();
                Destroy(gameObject);
            }
        }
        if (other.gameObject.GetComponent<Destructible>())
        {
            Destroy(gameObject);

        }
    }
}