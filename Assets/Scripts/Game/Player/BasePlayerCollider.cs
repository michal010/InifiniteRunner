using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerCollider
{
    void OnTriggerEnter(Collider other);
}

public class BasePlayerCollider : IPlayerCollider
{
    public virtual void OnTriggerEnter(Collider other)
    {
        
    }
}
