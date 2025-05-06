using UnityEngine;

public class BossMelee : MonoBehaviour
{
    [Header("References")]
    private Transform player;
    private Rigidbody2D rb;

    public bool near;
    private bool hasCharged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void chargeReset()
    {
        hasCharged = false;
    }
}
