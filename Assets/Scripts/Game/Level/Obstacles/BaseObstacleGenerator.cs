using UnityEngine;

public interface IObstacleGenerator
{
    abstract void GenerateObstacles(MapSegmentDataSO data, Transform parent);
}

public abstract class BaseObstacleGenerator : IObstacleGenerator
{
    public abstract void GenerateObstacles(MapSegmentDataSO data, Transform parent);
}