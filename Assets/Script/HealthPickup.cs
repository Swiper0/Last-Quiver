using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 1;

    void Update()
    {

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Tambahkan health jika masih di bawah health maksimum
                if (player.health < player.maxHealth)
                {
                    player.health += healthAmount;

                    // Agar health tidak melebihi batas maksimum
                    player.health = Mathf.Clamp(player.health, 0, player.maxHealth);
                    player.UpdateHeartsDisplay();
                }

                Destroy(gameObject);
            }
        }
    }
}
