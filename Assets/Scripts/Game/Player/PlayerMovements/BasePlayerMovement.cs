using UnityEngine;

public interface IPlayerMovement
{
    public void MovePlayer(Vector3 movementVector);
    public void OnJumpButton();
    public void OnCrouchButton();
}

public abstract class BasePlayerMovement : IPlayerMovement
{
    protected IBasePlayerMovementDataProvider baseDataProvider;

    public BasePlayerMovement(IBasePlayerMovementDataProvider baseDataProvider)
    {
        this.baseDataProvider = baseDataProvider;
    }

    public abstract void MovePlayer(Vector3 movementVector);
    public abstract void OnJumpButton();
    public abstract void OnCrouchButton();
}
