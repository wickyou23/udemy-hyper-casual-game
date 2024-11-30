using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static Action<GameState> OnGameStateChanged;

    public enum GameState { Menu, Game, LevelEnd, GameOver }

    private GameState currentGameState;

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
}
