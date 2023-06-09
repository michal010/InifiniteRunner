using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
public class ObstacleDataSO : ScriptableObject
{
    public GameObject ObstaclePrefab;
    public Vector3 ObstaclePosition;
    public Quaternion ObstacleQuaterion;
}