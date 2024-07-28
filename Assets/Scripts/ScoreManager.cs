using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI homeScoreText;
    [SerializeField] private TextMeshProUGUI awayScoreText;
    [SerializeField] private string homePrefix = "HOME: ";
    [SerializeField] private string awaySuffix = " :AWAY";

    private int homeScore = 0;
    private int awayScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreDisplay();
    }

    public void IncrementHomeScore()
    {
        homeScore++;
        UpdateScoreDisplay();
    }

    public void IncrementAwayScore()
    {
        awayScore++;
        UpdateScoreDisplay();
    }

    public void ResetScores()
    {
        homeScore = 0;
        awayScore = 0;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (homeScoreText != null)
        {
            homeScoreText.text = homePrefix + homeScore.ToString();
        }
        else
        {
            Debug.LogWarning("Home ScoreText is not assigned in the ScoreManager!");
        }

        if (awayScoreText != null)
        {
            awayScoreText.text = awayScore.ToString() + awaySuffix;
        }
        else
        {
            Debug.LogWarning("Away ScoreText is not assigned in the ScoreManager!");
        }
    }

    public int GetHomeScore()
    {
        return homeScore;
    }

    public int GetAwayScore()
    {
        return awayScore;
    }
}