using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameType { Endless, Story }

public interface IGameManager
{
    UnityEvent OnGameManagerTickEvent { get; }
}

public class GameManager : MonoBehaviour, IGameManager
{
    public GameType gameType = GameType.Endless;

    public UnityEvent OnGameManagerTickEvent { get; private set; }

    private IGame game;

    // Start is called before the first frame update
    void Awake()
    {
        OnGameManagerTickEvent = new UnityEvent();
        // Initialize all systems
        switch (gameType)
        {
            case GameType.Endless:
                game = new EndlessGame(this);
                break;
            case GameType.Story:
                break;
        }
        // Start game
        game.StartGame();
    }
    void Update()
    {
        OnGameManagerTickEvent?.Invoke();
    }
}
