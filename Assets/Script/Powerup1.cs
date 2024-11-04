using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup1 : MonoBehaviour
{
    public float duration = 5f;  // Durasi power-up

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Set time between shots to 0.1 and start power-up duration coroutine
                player.ActivateRapidFire(duration);
            }

            // Destroy the power-up item after it's picked up
            Destroy(gameObject);
        }
    }
}
