using UnityEngine;

public class ChargingScript : MonoBehaviour
{

    public float chargeSpeed = 50f;
    private bool hasCharged;
    public bool near;

    [Header("References")]
    private Transform player;
    private Rigidbody2D rb;

    private Vector2 chargeDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasCharged && PlayerInRange(near))
        {
            SetChargeDirection();
            StartCharge();
        }
    }

    public bool PlayerInRange(bool detect)
    {
        if (detect)
        {
            near = detect;
            return near;
        }
        else
        {
            near = detect;
            return near;
        }
    }

    void SetChargeDirection()
    {
        chargeDirection = (player.position - transform.position).normalized;
    }

    void StartCharge()
    {
        hasCharged = true;
        rb.linearVelocity = chargeDirection * chargeSpeed;
    }

    public void chargeReset()
    {
        hasCharged = false;
    }
}
