﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentStage = 0;
    public Person person;
   

    // Update is called once per frame
    void Update() {
        // TODO implement menu pausing
        if (Input.GetKeyDown(KeyCode.Escape)) {
            print("game is paused");
        }
    }

    private void Awake() {
        // Maintain the same instance across the game
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else {
            Destroy(gameObject);
        }
        NextStage();        
    }

    public void NextStage()
    {
        currentStage++;
        SceneManager.LoadScene(currentStage);
    }

    public void NewGame()
    {
        person = null;
        currentStage = 1;
        SceneManager.LoadScene(currentStage);
    }

    
}

