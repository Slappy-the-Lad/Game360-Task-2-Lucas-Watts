using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
 
    public TMP_Text scoretext;
    public TMP_Text highscore;
    private int savescore;
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
        SceneManager.LoadScene(0);
    }
}
