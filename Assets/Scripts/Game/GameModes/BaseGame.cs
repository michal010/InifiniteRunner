using UnityEngine;

public interface IGame
{
    LevelGenerator LevelGenerator { get; }
    void SpawnPlayer();
    void StartGame();
    void EndGame();
}

public class BaseGame : IGame
{
    public IPlayer player;
    public UIManager uiManager;
    public LevelDistance levelDistanceScore;
    public LevelGenerator LevelGenerator { get; protected set; }

    protected IGameManager gameManager;

    public BaseGame(IGameManager gameManager)
    {
        this.gameManager = gameManager;
        SpawnPlayer();
    }


    public virtual void EndGame()
    {
    }

    public virtual void StartGame()
    {
    }

    public virtual void SpawnPlayer()
    {
    }
}
