using System;
using UnityEditor.Build.Player;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;
    private int score;

    private void OnEnable() => CoinScript.OnCoinCollected += AddScore;
    private void OnDisable() => CoinScript.OnCoinCollected -= AddScore;

    private void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score); 
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
