using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;

public class ScoreUI : MonoBehaviour
{
 
    public TMP_Text scoretext;
    public TMP_Text highscore;
    public TMP_Text livestext;
    private int savescore;
    public GameManager gameManager;

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScore;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.Enter(GameState.Playing);
        savescore = PlayerPrefs.GetInt("HighScore");
        scoretext.text = "Score: 0";
        highscore.text = "High Score: " + savescore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateScore(int s, int hs)
    {
        scoretext.text = "Score: " + s;
        highscore.text = "High Score: " + hs;

    }
       public void RestartButton()
    {
        print("Heloo");
        //gameManager.Enter(GameState.Playing);
        SceneManager.LoadScene(0);
    }
}
