using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform firePoint;
    
    private Rigidbody2D rb; //reference to player rigidbody
    private Vector2 input; //reference to keyboard

    private void Awake() => rb = GetComponent<Rigidbody2D>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = Vector2.zero;
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;

        //This code is for player movement

        if ((kb.aKey.isPressed) || (kb.leftArrowKey.isPressed))
        {
            input.x = -1;
        }
        if ((kb.sKey.isPressed) || (kb.downArrowKey.isPressed))
        {
            input.y = -1;
        }
        if ((kb.dKey.isPressed) || (kb.rightArrowKey.isPressed))
        {
            input.x = +1;
        }
        if ((kb.wKey.isPressed) || (kb.upArrowKey.isPressed))
        {
            input.y = +1;
        }

        if (Input.GetMouseButtonDown(0))//done this way so it only activates once instead of every frame.
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets the mouse position
            Vector2 shootAngle = mousePos - firePoint.transform.position; //compares position of mouse and player to get an angle
            float angle = Mathf.Atan2(shootAngle.y,shootAngle.x) * Mathf.Rad2Deg; //wizardry
            firePoint.transform.rotation = quaternion.Euler(0,0,angle); //faces the angle in the right direction
            Instantiate(playerBullet, firePoint.transform.position, quaternion.identity);//spawns bullet
        }
    }

    private void FixedUpdate() => rb.linearVelocity = input * speed;
}
