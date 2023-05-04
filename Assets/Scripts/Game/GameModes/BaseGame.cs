using UnityEngine;

public interface IGame
{
    void StartGame();
    void EndGame();
}

public class BaseGame : IGame
{
    Vector3 playerSpawnPoint = Vector3.zero;
    
    //[Inject]
    public IPlayer player;
    public UIManager uiManager;

    protected IGameManager gameManager;

    public BaseGame(IGameManager gameManager)
    {
        this.gameManager = gameManager;
        

        // TODO: How to inject IPlayer to monobehaviour directly
        // Spawn player
        GameObject playerGo = MonoFactory.Create<GameObject>("Player");
        playerGo.transform.position = playerSpawnPoint;
        player = playerGo.GetComponent<IPlayer>();

        // Attach collision event, move this to EndlessGame for proper hook.
        playerGo.GetComponent<PlayerCollider>().playerCollider = new EndlessGamePlayerCollider();
        
    }


    public virtual void EndGame()
    {
        throw new System.NotImplementedException();
    }

    public virtual void StartGame()
    {

        
    }
}
