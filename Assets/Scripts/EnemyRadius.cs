using UnityEngine;

public class EnemyRadius : MonoBehaviour
{
    public EnemyScript enemyScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyScript = GetComponentInParent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyScript.inRange = true;
            enemyScript.Enter(EnemyState.Approach);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyScript.inRange = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyScript.inRange = true;
            enemyScript.Enter(EnemyState.Approach);
        }
    }
}
