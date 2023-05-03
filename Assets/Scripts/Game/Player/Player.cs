using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    Transform transform { get; }
}

[FromFactory("Player", true)]
public class Player : MonoBehaviour, IPlayer
{
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private IPlayerCollider playerCollider;

    public Transform position { get { return gameObject.transform; } }

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        playerMovement = new PlayerMovement(GetComponent<Rigidbody>(), this, new LevelBoundary(-3.5f,3.5f));
        playerCollider = new BasePlayerCollider();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.GetMovementInput();
        playerMovement.MovePlayer(playerInput.MovementInputVector);
    }
}
