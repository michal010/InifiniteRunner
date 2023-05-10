using UnityEngine;

public interface ILevelGenerator
{
    void GenerateLevel();
    void OnPlayerEnteredAnySegment();
}

public class LevelGenerator : ILevelGenerator
{
    ISegmentGenerator segmentGenerator;
    IObstacleGenerator obstacleGenerator;

    public LevelGenerator(ISegmentGenerator segmentGenerator, IObstacleGenerator obstacleGenerator)
    {
        this.segmentGenerator = segmentGenerator;
        this.obstacleGenerator = obstacleGenerator;
       //GameManager.Instance.OnGameManagerTickEvent.AddListener(segmentGenerator.CheckForSegmentGeneration);
    }

    public void GenerateLevel()
    {
        // generate level...
        segmentGenerator.GenerateLevel();
    }

    public void OnPlayerEnteredAnySegment()
    {
        Debug.Log("Player entered any segment");
        segmentGenerator.EnteredSegments++;
        segmentGenerator.DestroyLastSegment();
        segmentGenerator.GenerateNextSegment();
    }
}
