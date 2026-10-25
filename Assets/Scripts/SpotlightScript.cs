using System;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{
    private float timer = 5;
    private float resetTimer = 1;
    private bool playerSpotted = false;
    public static event Action OnPlayerDetect;
    public static event Action OnPlayerLeave;
    public static event Action OnPlayerStay;
    public List<EnemyScript> enemyScript = new List<EnemyScript>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0 && playerSpotted == true)
            {
                resetTimer = 1;
                OnPlayerDetect.Invoke();
            }
         
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //enemyScript.Add(GameObject.FindGameObjectsWithTag("Enemy").GetComponent<EnemyScript>());
        if(collision.CompareTag("Player"))
        {
            //enemyScript = GetComponents<EnemyScript>();
            OnPlayerStay.Invoke();
            playerSpotted = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnPlayerLeave.Invoke();
            playerSpotted = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
         
            OnPlayerDetect.Invoke();
         timer = 5;
        resetTimer = 1;   
        }
        
    }
}
