using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{
 
    public TMP_Text scoretext;
    public TMP_Text highscore;
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
        scoretext.text = "Score: 0";
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
}
