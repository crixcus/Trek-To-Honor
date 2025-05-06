using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public bool continuePatrol;

    private Transform targetPoint;

    void Start()
    {
        targetPoint = pointB;
    }

    void Update()
    {
        if (Roam(continuePatrol))
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }

    public bool Roam(bool detect)
    {
        if (detect)
        {
            continuePatrol = detect;
            return continuePatrol;
        }
        else
        {
            continuePatrol = detect;
            return continuePatrol;
        }
    }
}
