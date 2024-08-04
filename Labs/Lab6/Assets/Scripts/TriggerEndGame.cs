using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerController =
            other.gameObject.GetComponent<PlayerController>();
        playerController.Win();
    }
}
