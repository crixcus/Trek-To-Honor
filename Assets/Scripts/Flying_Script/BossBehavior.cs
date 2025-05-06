using System.Runtime.CompilerServices;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private GameObject Player;
    public BossHealth bossFire;

    private bool hasLineOfSight = false;
    public bool canAim = false;

    [Header("Firing")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireCooldown = 2f;
    private float fireTimer = 0f;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (hasLineOfSight && fireTimer >= fireCooldown)
        {
            FireAtPlayer();
            fireTimer = 0f;
        }
    }


    private void FixedUpdate()
    {
        if (canAim)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
            if (ray.collider != null)
            {
                hasLineOfSight = ray.collider.CompareTag("Player");
                if (hasLineOfSight)
                {
                    Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.green);
                }
                else
                {
                    Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red);
                }
            }
        }
    }

    public void drawRay()
    {
        if (bossFire.health < +200)
        {
            canAim = true;
        }
    }
    public void dontDrawRay()
    {
        canAim = false;
        hasLineOfSight = false;
    }

    private void FireAtPlayer()
    {
        if (bulletPrefab == null || firePoint == null || Player == null) return;

        Vector2 direction = (Player.transform.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float bulletSpeed = 50f;
            rb.linearVelocity = direction * bulletSpeed;
        }
    }

}
