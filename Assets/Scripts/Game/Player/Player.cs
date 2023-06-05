using System;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    Transform Transform { get; }
    Animator Animator { get; }
    Rigidbody Rigidbody { get; }
    PlayerCollision Collision { get; }

    void ChangePlayerController(PlayerControllerType Type);
}

[FromFactory("Player", true)]
public class Player : MonoBehaviour, IPlayer
{
    public Transform Transform { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public PlayerCollision Collision { get; private set; }
    public IPlayerController PlayerController { get; private set; }

    private PlayerInput playerInput;
    private Dictionary<PlayerControllerType, Type> playerControllerDict = new Dictionary<PlayerControllerType, Type>()
    {
        { PlayerControllerType.RunningPlayer,  typeof(RunningPlayerController) },
        { PlayerControllerType.SkateboardingPlayer, typeof(SkateboardingPlayerController) }
    };



    // Start is called before the first frame update
    void Awake()
    {
        // Fetch player's components
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        Transform = gameObject.GetComponent<Transform>();
        Animator = gameObject.GetComponentInChildren<Animator>();
        Collision = GetComponent<PlayerCollision>();
        //
        playerInput = new PlayerInput();
        PlayerController = new RunningPlayerController(playerInput, this);
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.GetMovementInput();
        playerInput.GetButtonInput();
        PlayerController.UpdatePlayer();
        if (Input.GetKeyDown(KeyCode.R))
            PlayerController = new SkateboardingPlayerController(playerInput,this);
        if (Input.GetKeyDown(KeyCode.T))
            PlayerController = new RunningPlayerController(playerInput, this);
    }

    public void ChangePlayerController(PlayerControllerType Type)
    {
        Type controllerType; 
        playerControllerDict.TryGetValue(Type, out controllerType);
        if(controllerType != null)
            PlayerController =  (IPlayerController)Activator.CreateInstance(controllerType, playerInput, this);
    }
}