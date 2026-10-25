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
    void OnEnable()
    {
        SpotlightScript.OnPlayerStay += playerSpotted;
       
        SpotlightScript.OnPlayerLeave += playerLeave;
        
        BulletScript.OnEnemyHit += React;

    }

    // Update is called once per frame
    void OnDisable()
    
    {
        
        SpotlightScript.OnPlayerStay -= playerSpotted;
       
        SpotlightScript.OnPlayerLeave -= playerLeave;
        
        BulletScript.OnEnemyHit -= React;

    }
       private IEnumerator Flash()
        {
        this.sr.color = Color.skyBlue;
        yield return new WaitForSeconds(0.3f);
        this.sr.color = Color.red;
        }
    public void Enter(EnemyState change)
    {
        if (change == EnemyState.Idle)
        {
            State = change;
        }
        if (change == EnemyState.Approach && inSpotlight == false)
        {
            State = change;
        }
        if (inSpotlight)
        {
            State = EnemyState.Spotted;
        }
       
    }
    void Update()
    {
        if (State == EnemyState.Approach)
        {
            Approach();
        }
        else if(State == EnemyState.Spotted)
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
            if (inSpotlight)
            {
                State = EnemyState.Spotted;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void Spotted()
    {
        if (player != null)
        {
            if (!inSpotlight)
            {
                State = EnemyState.Approach;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (speed * 1.5f) * Time.deltaTime);
        }
    }
    public void playerSpotted()
    {
        Enter(EnemyState.Spotted);
        inSpotlight = true;
    }
    public void playerLeave()
    {
        
        inSpotlight = false;
        Enter(EnemyState.Idle);
    }
}
