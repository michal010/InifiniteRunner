using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndlessSegmentGenerator : SegmentGenerator
{
    private const string ENDLESS_SEMGNETS_DATA_PATH = "EndlessSegmentData";
    private List<MapSegmentDataSO> mapSegmentDataSOs;


    public EndlessSegmentGenerator(IPlayer player) : base(player)
    {
        mapSegmentDataSOs = new List<MapSegmentDataSO>();
        //Loading should be moved to separate class, or use adressables?
        LoadSegmentsData();
    }

    public override void GenerateNextSegment()
    {
        // Choose random segment to spawn
        int randomSegmentIndex = UnityEngine.Random.Range(0, mapSegmentDataSOs.Count);
        MapSegmentDataSO randomSegment = mapSegmentDataSOs[randomSegmentIndex];
        base.GenerateSegment(randomSegment);
        
        // OnSegmentGeneratedEvent += obstacleGenerator.GenerateObstacles;
        //OnSegmentGeneratedEvent?.Invoke(mapSegment);
    }

    private void LoadSegmentsData()
    {
        mapSegmentDataSOs.Clear();
        mapSegmentDataSOs = Resources.LoadAll(ENDLESS_SEMGNETS_DATA_PATH, typeof(MapSegmentDataSO)).Cast<MapSegmentDataSO>().ToList();
    }
}
