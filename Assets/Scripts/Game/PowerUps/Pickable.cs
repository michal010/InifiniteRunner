using UnityEngine;

public interface IPickable
{
    void OnPickUp();
}

public abstract class Pickable : MonoBehaviour, IPickable
{
    public abstract void OnPickUp();
}
