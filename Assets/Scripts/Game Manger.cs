using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance { get; private set; }

    private TMP_Text scoreUI;

    private int currentSceneIndex;

    private int currentScore = 0;
    private int maxScore;

    private GameObject[] points;

    private void Awake()
    {
        if(Instance == null)
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
        SceneManager.sceneLoaded += OnSceneLoaded;

        points = GameObject.FindGameObjectsWithTag("Point");
        maxScore = points.Length;

        Scene currentScene = SceneManager.GetActiveScene();

        currentSceneIndex = currentScene.buildIndex;
    }

    public void addScore(int score)
    {
        if(scoreUI == null)
        {
            scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
        }

        currentScore += score;
        scoreUI.text = "Score: " + currentScore;

        if(currentScore == maxScore)
        {
            changeScene(currentSceneIndex + 1);
        }
    }

    private void changeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        points = GameObject.FindGameObjectsWithTag("Point");
        currentScore = 0;
        maxScore = points.Length;

        Scene currentScene = SceneManager.GetActiveScene();

        currentSceneIndex = currentScene.buildIndex;
    }
}
