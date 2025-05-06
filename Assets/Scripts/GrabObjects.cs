using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform gPoint; // grab point
    [SerializeField] private Transform rayPoint; // raycast poisition
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private LayerMask grabLayerMask; 

    private GameObject grabbedObj;
    private Rigidbody2D grabbedRb;
    private Collider2D grabbedCollider;
    private float originalGravityScale;
    private bool grab;

    private void Update()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            rayPoint.localPosition = new Vector3(-Mathf.Abs(rayPoint.localPosition.x), rayPoint.localPosition.y, rayPoint.localPosition.z);
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            rayPoint.localPosition = new Vector3(Mathf.Abs(rayPoint.localPosition.x), rayPoint.localPosition.y, rayPoint.localPosition.z);
        }

        Vector2 rayDirection = (rayPoint.localPosition.x > 0) ? Vector2.right : Vector2.left;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayDirection, rayDistance, grabLayerMask);



        if (hitInfo.collider != null && grabbedObj == null)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                grabbedObj = hitInfo.collider.gameObject;
                grabbedRb = grabbedObj.GetComponent<Rigidbody2D>();
                if (grabbedRb.bodyType == RigidbodyType2D.Kinematic)
                {
                    grabbedRb.bodyType = RigidbodyType2D.Dynamic; 
                }
                grabbedCollider = grabbedObj.GetComponent<Collider2D>();

                if (grabbedRb != null && grabbedCollider != null)
                {
                    originalGravityScale = grabbedRb.gravityScale;
                    grabbedRb.gravityScale = 0; 
                    grabbedRb.linearVelocity = Vector2.zero; 
                    grabbedRb.freezeRotation = true; 

                    grabbedCollider.isTrigger = true; 

                    grabbedObj.transform.SetParent(gPoint);
                }
            }
        }

        if (grabbedObj != null)
        {
            grabbedObj.transform.position = Vector2.Lerp(grabbedObj.transform.position, gPoint.position, Time.deltaTime * 10f);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (mousePosition - grabbedObj.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            grabbedObj.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && grabbedObj != null)
        {
            grabbedRb.freezeRotation = false; 
            grabbedCollider.isTrigger = false; 
            grabbedObj.transform.SetParent(null); 

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 throwDirection = (mousePosition - grabbedObj.transform.position).normalized;

            grabbedRb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
            SoundManager.Instance.PlayShootSound();

            grabbedRb.gravityScale = originalGravityScale; 

            // release references
            grabbedObj = null;
            grabbedRb = null;
            grabbedCollider = null;
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance, Color.red);
    }
}
