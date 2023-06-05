using UnityEngine;

public class SkateboardingPlayerController : BasePlayerController
{
    public SkateboardingPlayerController(PlayerInput playerInput, IPlayer player) : base(playerInput, player)
    {
        PlayerMovement = new SkateboardingPlayerMovement(
            new SkateboardingPlayerMovementData(player,
                new LevelBoundary(-3.5f,3.5f),
                5f,
                5f
                )
            );
        player.Collision.playerCollider = new SkateboardingPlayerCollider(
            new SkateboardingPlayerColliderData((SkateboardingPlayerMovement)PlayerMovement)
            );
        player.Animator.SetTrigger("Skateboard");
    }

    public override void HookPlayerInput()
    {
        playerInput.OnJumpButton.AddListener(Jump);
        playerInput.OnCrouchButton.AddListener(Crouch);
    }

    void Jump()
    {
        PlayerMovement.OnJumpButton();
    }
    void Crouch()
    {
        PlayerMovement.OnCrouchButton();
    }

}
