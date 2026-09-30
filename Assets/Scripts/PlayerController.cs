using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private GameObject bulletPrefab;
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

    }

    private void FixedUpdate() => rb.linearVelocity = input * speed;
}
