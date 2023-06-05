using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Inject logics
    public IPlayerCollider playerCollider;

    private void OnTriggerEnter(Collider other)
    {
        playerCollider.OnTriggerEnter(other);
    }
}
