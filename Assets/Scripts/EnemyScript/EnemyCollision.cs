using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public ShieldDeflect shieldCheck;
    public UIManager scoreCount;

    public int souls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.soulScore = souls;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            
            if(!shieldCheck.shieldHit)
            {
                souls++;
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Rata si player"); 
        }
    }
}
