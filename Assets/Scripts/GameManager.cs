using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [FormerlySerializedAs("Prefabs")]
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float ostacleOffsetX = 0f;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);
    public int score = 0;
    public bool isGameOver = false;

    public CanvasManager canvasManager;

    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public bool IsGameActive()
    {
        return !isGameOver;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public void EndGame()
    {
        // Set Flag
        isGameOver = true;

        // Print Message
        Debug.Log("GAME OVER ... You Score: " + score);

        // Reload scene
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // Wait
        yield return new WaitForSeconds(delay);

        // Reload Scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene Please!!!");

    }
}
