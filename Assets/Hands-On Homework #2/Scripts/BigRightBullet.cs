using UnityEngine;
using UnityEngine.UI;

public class BigRightBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform bulletTrash;

    public float bulletSpeed = 20f;
    public float bulletSize = 2f;
    public Color bulletColor = Color.red;

    public float shootCooldown = 0.5f;
    private float currentCooldown = 0f;

    public Image cooldownBar;

    void Start()
    {
        // Cooldown timer
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        // Update cooldown bar
        if (cooldownBar != null)
        {
            cooldownBar.fillAmount = 1 - (currentCooldown / shootCooldown);
        }

        // Right mouse button shoot
        if (Input.GetMouseButtonDown(1) && currentCooldown <= 0)
        {
            Shoot();
            currentCooldown = shootCooldown;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);

        bullet.transform.SetParent(bulletTrash);

        // Make bullet bigger
        bullet.transform.localScale *= bulletSize;

        // Change bullet color
        SpriteRenderer sr = bullet.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = bulletColor;
        }

        // Make bullet move faster
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }
}