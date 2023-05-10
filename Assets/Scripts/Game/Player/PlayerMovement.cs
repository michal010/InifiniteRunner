using UnityEngine;

public interface IPlayerMovement
{
    public void MovePlayer(Vector3 movementVector);
}

public class PlayerMovement : IPlayerMovement
{
    public float ForwardMovementSpeed = 3.5f;
    public float SideMovementSpeed = 5f;

    private LevelBoundary levelBoundary;
    private IPlayer player;

    public PlayerMovement(IPlayer player, LevelBoundary levelBoundary)
    {
        this.player = player;
        this.levelBoundary = levelBoundary;
    }

    public void MovePlayer(Vector3 movementVector)
    {
        player.Transform.Translate(player.Transform.forward * Time.deltaTime * ForwardMovementSpeed, Space.World);

        //  left movement
        if(movementVector.x < 0)
        {
            if (player.Transform.position.x > levelBoundary.LeftBoundary)
                player.Transform.Translate(player.Transform.right * Time.deltaTime * SideMovementSpeed * movementVector.x);
        }
        if(movementVector.x > 0)
        {
            if (player.Transform.position.x < levelBoundary.RightBoundary)
                player.Transform.Translate(player.Transform.right * Time.deltaTime * SideMovementSpeed * movementVector.x);
        }

    }
}
