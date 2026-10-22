using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
// Shows lives, the pause panel and the game over panel. Put it on the Canvas.
public class GameHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject pausePanel;
    private void Awake()
    {
        if (livesText == null) Debug.LogWarning(name + ": GameHUD has no Lives Text assigned.", this);
    if (pausePanel == null) Debug.LogWarning(name + ": GameHUD has no Pause Panel assigned.", this);
    if (pausePanel != null) pausePanel.SetActive(false);
        //ShowLives(GameManager.Instance.Lives);
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChanged += ShowPanels;
        GameManager.OnLivesChanged += ShowLives;
        if (GameManager.Instance != null)
        {
            ShowLives(GameManager.Instance.Lives);
            ShowPanels(GameManager.Instance.State);
        }
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= ShowPanels;
        GameManager.OnLivesChanged -= ShowLives;
    }
    private void ShowLives(int lives)
    {
        if (livesText != null) livesText.text = "Lives: " + lives;
    }
    private void ShowPanels(GameState state)
    {
        if (pausePanel != null) pausePanel.SetActive(state == GameState.Paused);
    }
    // ---- buttons ----
    public void OnResumeButton()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Enter(GameState.Playing);
    }
    public void OnReplayButton()
    {
        if (GameManager.Instance != null) GameManager.Instance.Restart();
    }
    public void OnQuitButton()
    {
        if (GameManager.Instance != null) GameManager.Instance.QuitGame();
    }
}
