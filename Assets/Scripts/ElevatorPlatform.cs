using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform pA; 
    public Transform pB; 

    public float speed = 2f;
    public float waitTime = 1f; 
    private bool movingUp = true;
    private bool isMoving = true;

    private Transform Player;

    private void Start()
    {
        StartCoroutine(MoveElevator());
    }

    private IEnumerator MoveElevator()
    {
        while (true)
        {
            Transform target = movingUp ? pA : pB;
            isMoving = true;

            while (Vector2.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }

            transform.position = target.position;
            isMoving = false;
            yield return new WaitForSeconds(waitTime);
            movingUp = !movingUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
