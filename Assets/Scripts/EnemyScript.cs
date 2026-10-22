using System;
using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyState State = EnemyState.Idle;
    public static event Action <EnemyState> OnEnemyStateChanged;
    private CircleCollider2D circleCollider;
    private SpriteRenderer sr;
    public bool inRange, inSpotlight;
    private void OnEnable()=> BulletScript.OnEnemyHit += React;
    private void OnDisable()=> BulletScript.OnEnemyHit -= React;
   private void React(int value)
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    public float speed = 6;
    public GameObject player;
    public int health = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindAnyObjectByType <PlayerController>().gameObject;
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    {
        

    }
       private IEnumerator Flash()
        {
        this.sr.color = Color.skyBlue;
        yield return new WaitForSeconds(0.3f);
        this.sr.color = Color.red;
        }
    public void Enter(EnemyState change)
    {
        State = change;

        if (inRange == true && inSpotlight == false)
        {
            Approach();
        }
        else if(inRange == true && inSpotlight == true)
        {
            Spotted();
        }
        else
        {
            Idle();
        }

    }
    
    private void Idle()
    {
       
    }
    private void Approach()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void Spotted()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (speed * 1.5f) * Time.deltaTime);
        }
    }
}
