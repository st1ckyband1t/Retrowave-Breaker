﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    //config parameters
    [Range(0.1f, 10f)][SerializeField] public float gameSpeed = 1f;
    [SerializeField] int blockBreakPoints;
    
    [SerializeField] TextMeshProUGUI scoreText;
    
    
    [SerializeField] bool isAutoplayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;

    //cachedvariable
    LoseCollider health;


    private void Awake()
    {
       
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        
        
        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void Start()
    {
        scoreText.text = currentScore.ToString();
       
        
    }

	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddScore()
    {
        currentScore += blockBreakPoints;
        scoreText.text = currentScore.ToString();
    }

    public void DestroyScene()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
}
