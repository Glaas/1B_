using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickup : MonoBehaviour
{
    private enum UpgradeType
    {
        Fireball,
        GroundSlam
    }
    [SerializeField]
    private UpgradeType upgradeType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (upgradeType)
            {
                case UpgradeType.Fireball:
                    PlayerUpgradeState.instance.UpgradeFireball();
                    break;
                case UpgradeType.GroundSlam:
                    PlayerUpgradeState.instance.UpgradeGroundStomp();
                    break;
                default:
                    Debug.LogError("Howdy partnet, Upgrade type not set");
                    break;
            }
            PlayerSFX.instance.PlaySFX(PlayerSFX.instance.playerPickupUpgrade);
            Destroy(gameObject);
        }
    }

}
