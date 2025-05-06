using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRig : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Update()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            offset.x = -Mathf.Abs(offset.x); // Ensure offset.x is negative
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            offset.x = Mathf.Abs(offset.x); // Ensure offset.x is positive
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target not assigned!");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
