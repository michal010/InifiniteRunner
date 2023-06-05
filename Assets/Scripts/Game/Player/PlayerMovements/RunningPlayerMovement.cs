using UnityEngine;

public class RunningPlayerMovementData : IRunningPlayerMovementDataProvider
{
    public float ForwardMovementSpeed { get; private set; }
    public float SideMovementSpeed { get; private set; }
    public IPlayer Player { get; private set; }
    public LevelBoundary LevelBoundary { get; private set; }
    
    public RunningPlayerMovementData(IPlayer Player, LevelBoundary LevelBoundary, float ForwardMovementSpeed, float SideMovementSpeed)
    {
        this.ForwardMovementSpeed = ForwardMovementSpeed;
        this.SideMovementSpeed = SideMovementSpeed;
        this.Player = Player;
        this.LevelBoundary = LevelBoundary;
    }
}

public class RunningPlayerMovement : BasePlayerMovement
{
    private IRunningPlayerMovementDataProvider runningDataProvider;

    public RunningPlayerMovement(IRunningPlayerMovementDataProvider runningDataProvider) : base(runningDataProvider)
    {                
        this.runningDataProvider = runningDataProvider;
    }

    public override void MovePlayer(Vector3 movementVector)
    {
        runningDataProvider.Player.Transform.Translate(runningDataProvider.Player.Transform.forward * Time.deltaTime * runningDataProvider.ForwardMovementSpeed, Space.World);

        //  left movement
        if (movementVector.x < 0)
        {
            if (runningDataProvider.Player.Transform.position.x > runningDataProvider.LevelBoundary.LeftBoundary)
                runningDataProvider.Player.Transform.Translate(runningDataProvider.Player.Transform.right * Time.deltaTime * runningDataProvider.SideMovementSpeed * movementVector.x);
        }
        if (movementVector.x > 0)
        {
            if (runningDataProvider.Player.Transform.position.x < runningDataProvider.LevelBoundary.RightBoundary)
                runningDataProvider.Player.Transform.Translate(runningDataProvider.Player.Transform.right * Time.deltaTime * runningDataProvider.SideMovementSpeed * movementVector.x);
        }

    }

    public override void OnCrouchButton()
    {
        Debug.Log("Running Movement: crouch");
    }

    public override void OnJumpButton()
    {
        Debug.Log("Running Movement: jump");

    }
}
