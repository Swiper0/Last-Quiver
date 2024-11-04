using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform player;

    public int health;
    public int maxHealth;
    private Rigidbody2D rb;
    private HealthBar healthBar;

    [SerializeField] public int damageAmount = 1;
    private float damageCooldown = 2f;
    private float lastDamageTime = 0f;

    [SerializeField] private GameObject whiteSprite;
    [SerializeField] private float flashDuration = 0.1f;
    
    [SerializeField] private Animator animator; // Referensi ke komponen Animator
    [SerializeField] private float deathAnimationDuration = 1f; // Durasi animasi kematian
    private bool isDying = false; // Flag untuk mengecek apakah sedang dalam animasi mati
    [SerializeField] private GameObject itemDropPrefab;
    [SerializeField] private GameObject rapidFirePowerupPrefab; 
    [SerializeField] private float dropChance = 0.2f;

    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBar>();
        animator = GetComponent<Animator>(); // Dapatkan komponen Animator

        if (whiteSprite == null)
        {
            Debug.LogError("White Sprite reference is missing on " + gameObject.name);
        }
    }

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);

        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Ensure the player object has the 'Player' tag.");
        }

        if (whiteSprite != null)
        {
            whiteSprite.SetActive(false);
        }
    }

    void Update()
    {
        // Hanya bergerak jika tidak sedang dalam animasi mati
        if (player != null && !isDying)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            FlipTowardsPlayer();
        }
    }

    void FlipTowardsPlayer()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") && !isDying)
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDying)
        {
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                other.GetComponent<PlayerController>().TakeDamage(damageAmount);
                lastDamageTime = Time.time;
                Debug.Log("Player damaged by enemy.");
            }
        }
    }

    void TakeDamage(int damageAmount)
    {
        if (isDying) return; // Jangan terima damage jika sedang dalam animasi mati

        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        
        StartCoroutine(FlashEffect());

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator FlashEffect()
    {
        if (whiteSprite != null)
        {
            whiteSprite.SetActive(true);
            yield return new WaitForSeconds(flashDuration);
            whiteSprite.SetActive(false);
        }
    }

IEnumerator Die()
{
    isDying = true;

    if (GetComponent<Collider2D>() != null)
    {
        GetComponent<Collider2D>().enabled = false;
    }

    if (healthBar != null)
    {
        healthBar.gameObject.SetActive(false);
    }

    ScoreManager.scoreCount += 1;

    // Check for item drop chance (termasuk power-up)
    if (itemDropPrefab != null && Random.value <= dropChance)
    {
        Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
    }

    // Spawn power-up (misalnya dengan probabilitas tertentu)
    if (Random.value <= 0.2f)
    {
        // Pastikan prefabs RapidFirePowerup sudah di assign di inspector
        Instantiate(rapidFirePowerupPrefab, transform.position, Quaternion.identity);
    }

    if (animator != null)
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(deathAnimationDuration);
    }

    Destroy(gameObject);
}

}