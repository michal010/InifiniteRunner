using UnityEngine;

public class RunningPlayerColliderData : IRunningPlayerColliderDataProvider
{
    public RunningPlayerMovement runningPlayerMovement { get; private set; }

    public RunningPlayerColliderData(RunningPlayerMovement runningPlayerMovement)
    {
        this.runningPlayerMovement = runningPlayerMovement;
    }
}

public class RunningPlayerCollider : BasePlayerCollider
{
    IRunningPlayerColliderDataProvider runningPlayerColliderDataProvider;
    public RunningPlayerCollider(IRunningPlayerColliderDataProvider runningPlayerColliderDataProvider) : base(runningPlayerColliderDataProvider)
    {
        this.runningPlayerColliderDataProvider = runningPlayerColliderDataProvider;
    }

    public override void OnPlayerHitObstacle(Collider obstacle)
    {
        Debug.Log("Player hit obstacle called from RunningPlayerCollider!");
    }
}
