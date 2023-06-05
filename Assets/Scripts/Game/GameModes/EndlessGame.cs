using UnityEngine;

public class EndlessGame : BaseGame
{
    public EndlessGame(IGameManager gameManager) : base(gameManager)
    {
        LevelGenerator = new LevelGenerator(new EndlessSegmentGenerator(player), new EndlessObstacleGenerator());
        levelDistanceScore = new LevelDistance(player);
        uiManager = MonoFactory.CreateWithDepedency<EndlessGameUIManager,LevelDistance>("EndlessGameUIManager", levelDistanceScore);
        uiManager.transform.SetParent( GameObject.Find("UI_Container").transform, false) ;
    }

    public override void EndGame()
    {
        gameManager.OnGameManagerTickEvent.RemoveAllListeners();
    }

    public override void StartGame()
    {
        // Does nothing currently.
        base.StartGame();
        LevelGenerator.GenerateLevel();
        // Start new endless game...
        // Hook scoring system to tick system
        //gameManager.OnGameManagerTickEvent += levelDistanceScore.UpdateDistance;
        gameManager.OnGameManagerTickEvent.AddListener(levelDistanceScore.UpdateDistance);

    }

    public override void SpawnPlayer()
    {
        // TODO: How to inject IPlayer to monobehaviour directly
        // Spawn player
        GameObject playerGo = MonoFactory.Create<GameObject>("Player");
        playerGo.transform.position = DefaultGameSettings.PLAYER_SPAWN_POINT;
        player = playerGo.GetComponent<IPlayer>();
        // Attach collision event, move this to EndlessGame for proper hook.
    }
}
