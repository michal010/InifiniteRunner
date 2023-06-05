using UnityEngine;

public interface IPlayerCollider
{
    void OnTriggerEnter(Collider other);
    void OnPlayerHitObstacle(Collider obstacle);
}

public class BasePlayerCollider : IPlayerCollider
{
    protected IBasePlayerColliderDataProvider baseDataProvider;

    private string ObstacleTag = "Obstacle";
    private string PickableTag = "Pickable";

    public BasePlayerCollider(IBasePlayerColliderDataProvider baseDataProvider)
    {
        this.baseDataProvider = baseDataProvider;
    }

    public virtual void OnPlayerHitObstacle(Collider obstacle)
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        // Either get logic of collision from "other"
        // or resolve logic by object tag:
        if (other.tag == ObstacleTag)
        {
            OnPlayerHitObstacle(other);
            //GameManager.Instance.GameEvents.OnPlayerHit();
        }
        else if (other.tag == PickableTag)
        {
            IPickable pickable = other.GetComponent<IPickable>();
            pickable.OnPickUp();
        }
    }
}
