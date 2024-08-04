using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Obtain a reference to the Player's PlayerController
        var playerController =
            other.gameObject.GetComponent<PlayerController>();

        // Register damage with player
        playerController.PickUpCoin();

        // Make this object disappear
        Destroy(gameObject);
    }
}
