using System.Collections;
using UnityEngine;
using System.Security.Cryptography;

public class EnemyScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private void Awake()=> sr = GetComponent<SpriteRenderer>();
    private void OnEnable()=> BulletScript.OnEnemyHit += React;
    private void OnDisable()=> BulletScript.OnEnemyHit -= React;
   private void React()
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    public float speed = 6;
    public GameObject player;
    public int health = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
       private IEnumerator Flash()
        {
        sr.color = Color.skyBlue;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.white;
        }
}
