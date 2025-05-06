using TTH;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerKnockback : MonoBehaviour
{
    [Header ("Knockback values")]
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.2f;

    [Header("Player Attributes")]
    public int playerHealth;

    
    private bool isKnockedBack;
    private float knockbackTimer;

    [Header ("References")]
    private Rigidbody2D rb;
    private PlayerController playerController;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public UIManager UIManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        playerHealth = 3;
    }

    private void Update()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
                if (playerController != null)
                    playerController.canMove = true;
            }
        }

        if (playerHealth == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }

        if (playerHealth == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }

        if (playerHealth == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }

        if (playerHealth <= 0)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);

            UIManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isKnockedBack && collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("EWeapon"))
        {
            HealthReduce();

            Vector2 knockDirection = (transform.position - collision.transform.position).normalized;

            rb.linearVelocity = Vector2.zero;

            rb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);

            isKnockedBack = true;
            knockbackTimer = knockbackDuration;

            if (playerController != null)
                playerController.canMove = false;
        }
        if (!isKnockedBack && collision.collider.CompareTag("Boss"))
        {
            Vector2 knockDirection = (transform.position - collision.transform.position).normalized;

            rb.linearVelocity = Vector2.zero;

            rb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);

            isKnockedBack = true;
            knockbackTimer = knockbackDuration;

            if (playerController != null)
                playerController.canMove = false;
        }
    }

    public void HealthReduce()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
    }
}
