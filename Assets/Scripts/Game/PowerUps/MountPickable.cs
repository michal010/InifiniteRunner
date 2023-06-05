using UnityEngine;

public class MountPickable : Pickable
{
    [SerializeField]
    PlayerControllerType mountType;

    public override void OnPickUp()
    {
        GameManager.Instance.Game.player.ChangePlayerController(mountType);
        Destroy(gameObject);
    }
}
