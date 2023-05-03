using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    public void OnPlayerHit();
}

public class Obstacle : MonoBehaviour, IObstacle
{
    public virtual void OnPlayerHit()
    {
        //OnPlayerHit
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            OnPlayerHit();
    }
}
