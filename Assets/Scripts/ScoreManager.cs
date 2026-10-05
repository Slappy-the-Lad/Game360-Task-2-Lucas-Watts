using System;
using UnityEditor.Build.Player;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int, int> OnScoreChanged;
    private int score;
    private int highscore;

    private void OnEnable() => BulletScript.OnEnemyHit += AddScore;
    private void OnDisable() => BulletScript.OnEnemyHit -= AddScore;

    private void AddScore(int value)
    {
        score += value;
        if (score>highscore)
        {
            highscore = score;
        }
        OnScoreChanged?.Invoke(score, highscore);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
