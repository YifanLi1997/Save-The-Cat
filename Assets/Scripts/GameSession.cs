﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config paras
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int scorePerBlockDestroyed = 10;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}