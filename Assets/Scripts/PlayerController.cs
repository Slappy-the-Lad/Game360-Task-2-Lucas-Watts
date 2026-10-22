using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform firePoint;
    public int HP = 3;
    public GameObject GameOverScreen, actualGameOVer;
    private Rigidbody2D rb; //reference to player rigidbody
    private Vector2 input; //reference to keyboard
    public GameManager gameManager;

    private void Awake() => rb = GetComponent<Rigidbody2D>();
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerPrefs.GetInt("Lives", gameManager.Lives);
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

        if (mouse.leftButton.wasPressedThisFrame)//done this way so it only activates once instead of every frame.
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets the mouse position
            Vector2 shootAngle = mousePos - firePoint.transform.position; //compares position of mouse and player to get an angle
            shootAngle.Normalize(); //makes it so distance of mouse and player doesn't affect bullet speed
            float angle = Mathf.Atan2(shootAngle.y,shootAngle.x) * Mathf.Rad2Deg; //wizardry
            firePoint.transform.rotation = quaternion.Euler(0,0,angle); //faces the angle in the right direction
            GameObject bullet = Instantiate(playerBullet, firePoint.transform.position, quaternion.identity);//spawns bullet
            bullet.GetComponent<BulletScript>().input = shootAngle; //fires the bullet using the bullet script
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP --;
            if (HP == 0)
            {
                
                gameManager.Lives -= 1;
                PlayerPrefs.SetInt("Lives", gameManager.Lives);
                if (gameManager.Lives != 0)
                {
                    GameOverScreen.SetActive(true);
                    
                }
                else
                {
                    actualGameOVer.SetActive(true);
                    gameManager.Lives = 3;

                }
                    
                Destroy(this.gameObject);
                gameManager.Enter(GameState.GameOver);
            }
        }
    }
 

    private void FixedUpdate() => rb.linearVelocity = input * speed;
}
