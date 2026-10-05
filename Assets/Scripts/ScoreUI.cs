using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
 
    public TMP_Text scoretext;
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

    void UpdateScore(int s) =>
        scoretext.text = "Score: " + s;

}
