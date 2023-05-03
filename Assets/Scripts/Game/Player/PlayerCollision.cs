using UnityEngine;

public class PlayerCollision
{
    private IPlayerCollider playerCollider;

    public PlayerCollision(IPlayerCollider playerCollider)
    {
        this.playerCollider = playerCollider;
    }

    public void OnTriggerEnter(Collider collider)
    {
        playerCollider.OnTriggerEnter(collider);
    }
}
