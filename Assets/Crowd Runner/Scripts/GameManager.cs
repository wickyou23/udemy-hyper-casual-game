using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static Action<GameState> OnGameStateChanged;

    public enum GameState { Menu, Game, LevelCompleted, GameOver }

    private GameState currentGameState;

    public bool isGameState => currentGameState == GameState.Game;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeGameState(GameState gameState)
    {
        currentGameState = gameState;
        OnGameStateChanged?.Invoke(currentGameState);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
