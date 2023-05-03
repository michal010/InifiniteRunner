using UnityEngine;

public interface IGame
{
    void StartGame();
    void EndGame();
}

public class BaseGame : IGame
{
    Vector3 playerSpawnPoint = Vector3.zero;

    protected IPlayer player;
    protected IGameManager gameManager;

    public BaseGame(IGameManager gameManager)
    {
        this.gameManager = gameManager;
        
        // Spawn player
        GameObject playerGo = MonoFactory.CreateGameObject<GameObject>("Player");
        playerGo.transform.position = playerSpawnPoint;
        player = playerGo.GetComponent<IPlayer>();
    }


    public virtual void EndGame()
    {
        throw new System.NotImplementedException();
    }

    public virtual void StartGame()
    {

        
    }
}
