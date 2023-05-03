public class EndlessGame : BaseGame
{
    LevelDistance levelDistanceScore;
    ISegmentGenerator segmentGenerator;
    IObstacleGenerator obstacleGenerator;

    public EndlessGame(IGameManager gameManager) : base(gameManager)
    {
        levelDistanceScore = new LevelDistance(player);
        obstacleGenerator = new ObstacleGenerator();
        segmentGenerator = new SegmentGenerator(obstacleGenerator, player, new UnityEngine.GameObject("Map").transform);
    }

    public new void EndGame()
    {
        throw new System.NotImplementedException();
    }

    public override void StartGame()
    {
        // Fire base function, spawn player, ...
        base.StartGame();
        
        // Start new endless game...
        segmentGenerator.GenerateLevel();
        // Hook scoring system to tick system
        //gameManager.OnGameManagerTickEvent += levelDistanceScore.UpdateDistance;
        gameManager.OnGameManagerTickEvent.AddListener(levelDistanceScore.UpdateDistance);
        gameManager.OnGameManagerTickEvent.AddListener(segmentGenerator.CheckForSegmentGeneration);

    }

}
