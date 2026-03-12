using UnityEngine;

public class BigRightBullet : MonoBehaviour
{
    public GameObject preFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    public float bulletForce = 20f; // Speed of the bullet

    private const float Timer = 1.5f; // Longer cooldown than left click
    private float _currentTime = 1.5f;
    private bool _canShoot = true;

    private void Update()
    {
        TimerMethod();
        ShootRight();
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }
    }

    private void ShootRight()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canShoot)
        {
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, bulletSpawn.rotation);

            bullet.transform.SetParent(bulletTrash);

            // Make the right-click bullet slightly bigger
            bullet.transform.localScale *= 1.5f;

            // Launch the bullet forward
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
            }

            _canShoot = false;
        }
    }
}