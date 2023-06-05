public interface IRunningPlayerMovementDataProvider : IBasePlayerMovementDataProvider
{
    public float ForwardMovementSpeed { get; }
    public float SideMovementSpeed { get; }
}
