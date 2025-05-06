using UnityEngine;

public class SmoothObjectFollow : MonoBehaviour
{
    public Transform target; // The object to follow
    public float followSpeed = 5f; // Speed of movement

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not assigned!");
            return;
        }

        // Smoothly move towards the target position
        transform.position = Vector2.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
    }
}
