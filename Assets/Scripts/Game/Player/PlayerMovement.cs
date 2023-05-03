using UnityEngine;

public class PlayerMovement
{
    public float ForwardMovementSpeed = 2f;
    public float SideMovementSpeed = 3f;

    private LevelBoundary levelBoundary;
    private Rigidbody rb;
    private IPlayer player;

    public PlayerMovement(Rigidbody rb, IPlayer player, LevelBoundary levelBoundary)
    {
        this.rb = rb;
        this.player = player;
        this.levelBoundary = levelBoundary;
    }

    public void MovePlayer(Vector3 movementVector)
    {
        player.transform.Translate(player.transform.forward * Time.deltaTime * ForwardMovementSpeed, Space.World);

        //  left movement
        if(movementVector.x < 0)
        {
            if (player.transform.position.x > levelBoundary.LeftBoundary)
                player.transform.Translate(player.transform.right * Time.deltaTime * SideMovementSpeed * movementVector.x);
        }
        if(movementVector.x > 0)
        {
            if (player.transform.position.x < levelBoundary.RightBoundary)
                player.transform.Translate(player.transform.right * Time.deltaTime * SideMovementSpeed * movementVector.x);
        }

    }
}
