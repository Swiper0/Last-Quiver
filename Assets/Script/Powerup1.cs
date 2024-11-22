using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup1 : MonoBehaviour
{
    public float duration = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateRapidFire(duration);
            }
            Destroy(gameObject);
        }
    }
}
