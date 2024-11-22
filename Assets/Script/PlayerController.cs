using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform weapon;
    public float offset;
    private Rigidbody2D rb;
    private bool facingRight = true;

    public Transform shotPoint;
    public GameObject projectile;

    public float timeBetweenShots;
    public float originalTimeBetweenShots;
    private Coroutine activePowerupCoroutine;
    float nextShotTime;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    public Animator animator;

    public int health = 3;
    public int maxHealth = 3;
    public GameObject heartPrefab;
    public Transform heartsContainer;
    private List<GameObject> hearts = new List<GameObject>();

    private bool canTakeDamage = true;

    public GameObject gameOverPannel;

    public GameOverPanelManager gameOverPanelManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        activeMoveSpeed = speed;
        originalTimeBetweenShots = timeBetweenShots;

        UpdateHeartsDisplay();
    }

    void Update()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 newPosition = transform.position + playerInput.normalized * activeMoveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x, 
                                          Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)).x);
        newPosition.y = Mathf.Clamp(newPosition.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y, 
                                          Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)).y);

        transform.position = newPosition;

        // Flip character
        if (playerInput.x < 0 && facingRight)
        {
            Flip();
        }
        else if (playerInput.x > 0 && !facingRight)
        {
            Flip();
        }

        // Weapon aiming
        weapon.position = new Vector3(transform.position.x, transform.position.y, weapon.position.z);
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);

        // Shooting projectile
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots;
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            }
        }

        // Dashing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                animator.SetBool("isDashing", true);
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
                animator.SetBool("isDashing", false);
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        animator.SetFloat("Speed", playerInput.magnitude);
    }

    public void ActivateRapidFire(float duration)
    {
        timeBetweenShots = 0.1f;

        // Jika korutin aktif untuk power-up, hentikan dulu agar durasi di-reset
        if (activePowerupCoroutine != null)
        {
            StopCoroutine(activePowerupCoroutine);
        }

        // Mulai korutin baru untuk mengatur ulang fire rate setelah durasi
        activePowerupCoroutine = StartCoroutine(ResetFireRateAfterDuration(duration));
    }

    private IEnumerator ResetFireRateAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        timeBetweenShots = originalTimeBetweenShots;
        activePowerupCoroutine = null;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void TakeDamage(int damageAmount)
    {
        if (!canTakeDamage) return;

        health -= damageAmount;
        Debug.Log("Player Health after damage: " + health);

        
        if (health <= 1)
        {
            gameOverPanelManager.ShowGameOverPanel();
            UpdateBestScore();
        }

        UpdateHeartsDisplay();

        // Set cooldown for damage intake
        StartCoroutine(DamageCooldown());
    }



    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.5f);
        canTakeDamage = true;
    }

    public void UpdateHeartsDisplay()
    {
        // Hapus heart yang ada
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();

        // Tambahkan heart sesuai health saat ini
        for (int i = 0; i < health; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            heart.transform.localPosition = new Vector3(i * 40, 0, 0);
            hearts.Add(heart);
        }

        Debug.Log("Hearts displayed: " + hearts.Count);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            int damage = other.GetComponent<Enemy>().damageAmount;
            Debug.Log("Player hit by enemy with damage: " + damage);
            TakeDamage(damage);
        }
    }

    private void ShowGameOverPannel(){
        gameOverPannel.SetActive(true);
        Time.timeScale = 0;
    }

    private void UpdateBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (ScoreManager.scoreCount > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", ScoreManager.scoreCount);
            PlayerPrefs.Save();
        }
    }
}
