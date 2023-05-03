using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleGenerator : BaseObstacleGenerator
{
    public static int MaxObstacles = 6;

    public int Rows = 10;
    public int Columns = 4;
    public float xPadding = 2f;
    public float zPadding = 2f;

    private List<ObstacleDataSO> obstacleDataSOs;
    private const string DATA_PATH = "ObstaclesData";

    public ObstacleGenerator()
    {
        obstacleDataSOs = new List<ObstacleDataSO>();
        LoadObstacleData();
    }

    private void LoadObstacleData()
    {
        obstacleDataSOs.Clear();
        obstacleDataSOs = Resources.LoadAll(DATA_PATH, typeof(ObstacleDataSO)).Cast<ObstacleDataSO>().ToList();
    }

    public override void GenerateObstacles(GameObject mapSegment)
    {
        for (int i = 0; i < MaxObstacles; i++)
        {
            // Choose random obstacle to spawn
            int randomObstacleIndex = UnityEngine.Random.Range(0, obstacleDataSOs.Count);
            int randomX = UnityEngine.Random.Range(0, Columns);
            int randomZ = UnityEngine.Random.Range(0, Rows);


            ObstacleDataSO randomSegment = obstacleDataSOs[randomObstacleIndex];
            Vector3 obstaclePos = new Vector3(randomX * xPadding, -1f, randomZ * zPadding);
            GameObject obstaclePrefab = randomSegment.ObstaclePrefab;

            GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
            obstacle.transform.parent = mapSegment.transform;
            obstacle.transform.localPosition = obstaclePos;
            obstacle.transform.rotation = Quaternion.identity;
        }
    }
}
