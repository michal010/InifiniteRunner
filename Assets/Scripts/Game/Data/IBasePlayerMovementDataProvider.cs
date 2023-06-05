public interface IBasePlayerMovementDataProvider : IDataProvider
{
    IPlayer Player { get; }
    LevelBoundary LevelBoundary { get; }
}
