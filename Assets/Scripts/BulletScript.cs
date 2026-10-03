using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    private Vector2 input; 
    private Rigidbody2D rb;
    public PlayerController playerController;
    private void Awake() => rb = GetComponent<Rigidbody2D>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate() => rb.linearVelocity = input * speed;
}
