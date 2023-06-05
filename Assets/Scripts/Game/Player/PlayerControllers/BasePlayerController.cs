public interface IPlayerController
{
    public void UpdatePlayer();
    public void HookPlayerInput();

    public IPlayerMovement PlayerMovement { get; }
    public IPlayerAnimator PlayerAnimator { get; }
    public IPlayerCollider PlayerCollider { get; }
}

public enum PlayerControllerType
{
    RunningPlayer,
    SkateboardingPlayer
}

public class BasePlayerController : IPlayerController
{
    public IPlayerMovement PlayerMovement { get; protected set; }
    public IPlayerAnimator PlayerAnimator { get; protected set; } 
    public IPlayerCollider PlayerCollider { get; protected set; }

    protected readonly PlayerInput playerInput;
    protected IPlayer player;
    public BasePlayerController(PlayerInput playerInput, IPlayer player)
    {
        this.playerInput = playerInput;
        this.player = player;
        playerInput.OnJumpButton.RemoveAllListeners();
        playerInput.OnCrouchButton.RemoveAllListeners();
        HookPlayerInput();
    }

    public void UpdatePlayer()
    {
        PlayerMovement.MovePlayer(playerInput.MovementInputVector);
    }

    public virtual void HookPlayerInput()
    {
    }
}
