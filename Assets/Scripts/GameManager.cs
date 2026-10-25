using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public static event Action <GameState> OnGameStateChanged;
    public static event Action<int> OnLivesChanged;
    [SerializeField] private int maxLives = 3;
    public GameState State = GameState.Playing;
    public int Lives;
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            enabled = false;
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    private void Start()
    {

        Lives = maxLives;
        OnLivesChanged?.Invoke(Lives);
        Enter(GameState.Playing);
    }
    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        //if (kb != null && kb.escapeKey.wasPressedThisFrame) TogglePause();'
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Ben");
            TogglePause();
        }
    }
    public void Enter(GameState next)
    {
        State = next;
        
        switch (next)
        {
            case GameState.Playing: Time.timeScale = 1f; break;
            case GameState.Paused: Time.timeScale = 0f; break;
            case GameState.GameOver: Time.timeScale = 0f;  break;
        }
        OnGameStateChanged?.Invoke(next);
        print("I'm in " + next);
    }
    //public void SetState(GameState next)
    //{
    //    //if (State == next) return;
    //    //if (State == GameState.GameOver) return;
    //    
    //    Enter(next);
    //}
    public void TogglePause()
    {
        
        if (State == GameState.Playing) Enter(GameState.Paused);
        else if (State == GameState.Paused) Enter(GameState.Playing);
    }
    // Called by the player when the enemy touches it.
    public void PlayerHit()
    {
        if (State != GameState.Playing) return;
        Lives--;
        if (Lives < 0) Lives = 0;
        OnLivesChanged?.Invoke(Lives);
        //if (Lives == 0) Enter(GameState.GameOver);
    }

    // ---- buttons ----
    public void Restart()
    {
        
        Enter(GameState.Playing);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quit pressed (does nothing in the Editor)");
        Application.Quit();
    }
}
