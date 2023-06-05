using UnityEngine;

public class RunningPlayerController : BasePlayerController
{
    public RunningPlayerController(PlayerInput playerInput, IPlayer player) : base(playerInput, player)
    {
        PlayerMovement = new RunningPlayerMovement(
            new RunningPlayerMovementData(
                player,
                new LevelBoundary(-3.5f, 3.5f),
                3.5f,
                5f
                )
            );

        player.Collision.playerCollider = new RunningPlayerCollider(
                new RunningPlayerColliderData((RunningPlayerMovement)PlayerMovement)
            );
        player.Animator.SetTrigger("Run");
    }

    public override void HookPlayerInput()
    {
        playerInput.OnJumpButton.AddListener(Jump);
        playerInput.OnCrouchButton.AddListener(Slide);
    }

    void Slide()
    {
        player.Animator.SetTrigger("Slide");
        Debug.Log("Sliding");
    }
    void Jump()
    {
        player.Animator.SetTrigger("Jump");
        Debug.Log("Jumping");
    }
}
