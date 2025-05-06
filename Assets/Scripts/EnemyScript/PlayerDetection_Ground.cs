using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerDetection_Ground : MonoBehaviour
{
    [field: SerializeField]

    public bool PlayerDetected { get; private set; }
    public Vector2 DirectionTarget => target.transform.position - detectorOrigin.position;

    [Header("OverlapBox Parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.3f;

    public LayerMask detectorLayerMask;

    [Header("Gizmno Parameters")]
    public Color gizmosIdleColor = Color.green;
    public Color gizmosDetectedColor = Color.red;
    public bool showGizmos = true;

    private GameObject target;
    public EnemyPatrol willPatrol;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            PlayerDetected = target != null;
        }
    }

    void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    public void PerformDetection()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);

        if (collider != null)
        {
            Target = collider.gameObject;
        }
        else
        {
            Target = null;
        }
    }

    private void OnDrawGizmos()
    {
        if(showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmosIdleColor;
            

            if (PlayerDetected)
            {
                Gizmos.color = gizmosDetectedColor;
                willPatrol.Roam(false);
                AttackPlayer();
            }
            else
            {
                willPatrol.Roam(true);
            }

            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }

    public void AttackPlayer()
    {
        if (target == null) return;

        float moveSpeed = 12f;

        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = target.transform.position;

        float directionX = Mathf.Sign(targetPosition.x - currentPosition.x);

        transform.Translate(Vector2.right * directionX * moveSpeed * Time.deltaTime);
    }
}
