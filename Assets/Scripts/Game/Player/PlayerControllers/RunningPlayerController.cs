using UnityEngine;

public class RunningPlayerController : BasePlayerController
{
    public RunningPlayerController(PlayerInput playerInput, IPlayer player) : base(playerInput, player)
    {
        PlayerMovement = new PlayerMovement(player, new LevelBoundary(-3.5f, 3.5f));
        player.Animator.SetTrigger("Run");
    }

    public override void HookPlayerInput()
    {
        playerInput.OnJumpButton.AddListener(Jump);
        playerInput.OnSlideButton.AddListener(Slide);
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
