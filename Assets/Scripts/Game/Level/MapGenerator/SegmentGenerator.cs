using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ISegmentGenerator
{
    public void GenerateLevel();
    public void GenerateNextSegment();
    public void GenerateSegment(MapSegmentDataSO data);
    public void DestroyLastSegment();
    public int EnteredSegments { get; set; }
    // Change to some custom data object
    public event Action<GameObject> OnSegmentGeneratedEvent;
}

public class SegmentGenerator : ISegmentGenerator
{
    public event Action<GameObject> OnSegmentGeneratedEvent;
    public int EnteredSegmentsRequiredToDestroyLastCreatedSegment = 3;
    public int StartingSegmentsCount = 6;

    public int EnteredSegments { get; set; }

    protected IPlayer player;
    protected GameObject lastSpawnedGameObject;
    protected Queue<GameObject> spawnedMapSegments;
    protected Transform mapSegmentParent;
    
    public SegmentGenerator(IPlayer player)
    {
        EnteredSegments = 0;
        spawnedMapSegments = new Queue<GameObject>();
        mapSegmentParent = new GameObject("Map").GetComponent<Transform>();
        this.player = player;
    }

    // Used on start of the game
    public void GenerateLevel()
    {
        for (int i = 0; i < StartingSegmentsCount; i++)
        {
            GenerateNextSegment();
        }
    }

    public virtual void GenerateNextSegment()
    {

    }

    public void DestroyLastSegment()
    {
        if (EnteredSegments < EnteredSegmentsRequiredToDestroyLastCreatedSegment)
            return;
        GameObject lastSegment = spawnedMapSegments.Dequeue();
        GameObject.Destroy(lastSegment);
    }

    public void GenerateSegment(MapSegmentDataSO mapSegment)
    {
        // Create new map segment set it away from view
        GameObject mapSegmentGO = GameObject.Instantiate(mapSegment.MapSegmnetPrefab, new Vector3(100,100,100), Quaternion.identity);

        Collider mapCollider = mapSegmentGO.GetComponent<Collider>();

        // Get oryginal position as saved in mapSegmentDataSO
        Vector3 oryginalPosition = mapSegment.MapSegmnetPrefab.transform.position;

        // Set new position for upcoming map segment
        float adjustedZ = 0;
        if (lastSpawnedGameObject != null)
        {
            adjustedZ = lastSpawnedGameObject.transform.position.z + GetColliderSize(mapCollider).z;
        }

        Vector3 newMapSegmentPosition = new Vector3(oryginalPosition.x, oryginalPosition.y, adjustedZ);
        mapSegmentGO.transform.position = newMapSegmentPosition;

        // Create new segment
        mapSegmentGO.GetComponent<Transform>().SetParent(mapSegmentParent);

        // Set last spawned map segment and enqueue it.
        lastSpawnedGameObject = mapSegmentGO;
        spawnedMapSegments.Enqueue(mapSegmentGO);
    }

    private Vector3 GetColliderSize(Collider collider)
    {
        return collider.bounds.size;
    }
}
