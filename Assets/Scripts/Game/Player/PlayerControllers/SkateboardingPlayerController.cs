using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardingPlayerController : BasePlayerController
{
    public SkateboardingPlayerController(PlayerInput playerInput, IPlayer player) : base(playerInput, player)
    {
        PlayerMovement = new PlayerMovement(player, new LevelBoundary(-3.5f, 3.5f));
        player.Animator.SetTrigger("Skateboard");
    }

    public override void HookPlayerInput()
    {
        playerInput.OnJumpButton.AddListener(Jump);
        playerInput.OnSlideButton.AddListener(Slide);
    }

    void Slide()
    {
        Debug.Log("Sliding");
    }
    void Jump()
    {
        Debug.Log("Jumping");
    }
}
