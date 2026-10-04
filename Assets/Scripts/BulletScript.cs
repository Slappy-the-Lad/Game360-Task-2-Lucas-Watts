using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
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

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3); // destroys bullet after 3 seconds
        Destroy(this.gameObject);
    }
}

