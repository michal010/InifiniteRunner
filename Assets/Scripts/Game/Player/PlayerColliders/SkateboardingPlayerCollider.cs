using UnityEngine;

public class SkateboardingPlayerColliderData : ISkateboardingPlayerColliderDataProvider
{
    public SkateboardingPlayerMovement skateboardingPlayerMovement { get; private set; }
    
    public SkateboardingPlayerColliderData(SkateboardingPlayerMovement skateboardingPlayerMovement)
    {
        this.skateboardingPlayerMovement = skateboardingPlayerMovement;
    }
}

public class SkateboardingPlayerCollider : BasePlayerCollider
{
    private ISkateboardingPlayerColliderDataProvider skateboardingPlayerColliderDataProvider;
    public SkateboardingPlayerCollider(ISkateboardingPlayerColliderDataProvider skateboardingPlayerColliderDataProvider) : base(skateboardingPlayerColliderDataProvider)
    {
        this.skateboardingPlayerColliderDataProvider = skateboardingPlayerColliderDataProvider;
    }

    public override void OnPlayerHitObstacle(Collider obstacle)
    {
        //If player was jumping, enter slide mode.
        switch (skateboardingPlayerColliderDataProvider.skateboardingPlayerMovement.state)
        {
            case SkateboardingState.Run:
                Debug.Log("Obstacle hit while running");
                break;
            case SkateboardingState.Jump:
                Debug.Log("Obstacle hit while JUMPING");
                break;
            case SkateboardingState.Sliding:
                break;
        }
    }
}
