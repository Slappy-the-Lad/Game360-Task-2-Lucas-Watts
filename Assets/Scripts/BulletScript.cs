using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
[RequireComponent (typeof(Collider2D))]

public class BulletScript : MonoBehaviour
{
    public static event Action OnEnemyHit;
    private int value = 10;
    [SerializeField] private float speed = 30.0f; //speed gets adjusted in unity editor
    public Vector2 input; 
    private Rigidbody2D rb;
    private void Awake() => rb = GetComponent<Rigidbody2D>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void FixedUpdate() => rb.linearVelocity = input * speed; //speed for bullet

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy") //enemy and wall collision scripts are seperated for observer class
        {
            OnEnemyHit.Invoke();
            other.gameObject.GetComponent<EnemyScript>().health--;
            if(other.gameObject.GetComponent<EnemyScript>().health == 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject); //destorys bullet on enemy collision.
        }

        if(other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject); //destorys bullet on wall collision.
        }
    }
    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3); // destroys bullet after 3 seconds
        Destroy(this.gameObject);
    }
 
}

