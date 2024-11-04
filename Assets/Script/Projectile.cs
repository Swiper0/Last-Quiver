using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    public float destroyOffset = 1f; // Jarak tambahan sebelum projectile di-destroy

    private Vector3 screenBottomLeft;
    private Vector3 screenTopRight;

    // Start is called before the first frame update
    void Start()
    {
        // Menghitung batas kamera
        screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)) - new Vector3(destroyOffset, destroyOffset, 0);
        screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)) + new Vector3(destroyOffset, destroyOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Gerakkan projectile ke atas sesuai dengan kecepatan
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Hancurkan projectile jika keluar dari batas layar (dengan offset)
        if (transform.position.x < screenBottomLeft.x || transform.position.x > screenTopRight.x ||
            transform.position.y < screenBottomLeft.y || transform.position.y > screenTopRight.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Hancurkan projectile jika menabrak objek selain player
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
