using TTH;
using UnityEngine;

public class ShieldDeflect : MonoBehaviour
{
    [Header ("Knockback Values")]
    private bool isKnockedBack;
    private float knockbackTimer;
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.2f;

    [Header ("Checking Weapon Status")]
    public bool shieldHit;
    private bool hasHit = false;

    private Rigidbody2D rb;
    public GameObject weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isKnockedBack && collision.collider.CompareTag("EWeapon"))
        {
            shieldHit = true;

            Vector2 knockDirection = (transform.position - collision.transform.position).normalized;

            rb.linearVelocity = Vector2.zero;

            rb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);

            isKnockedBack = true;
            knockbackTimer = knockbackDuration;
        }
        else
            shieldHit = false;

        if (!hasHit)
        {
            hasHit = true;

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearDamping = .3f;
            rb.angularDamping = .3f;
        }
    }
}
