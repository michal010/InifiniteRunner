using UnityEngine;

public interface IPlayer
{
    Transform Transform { get; }
    Animator Animator { get; }
    Rigidbody Rigidbody { get; }
}



[FromFactory("Player", true)]
public class Player : MonoBehaviour, IPlayer
{
    public Transform Transform { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }


    public IPlayerController PlayerController { get; private set; }

    private PlayerInput playerInput;


    // Start is called before the first frame update
    void Awake()
    {
        // Fetch player's components
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        Transform = gameObject.GetComponent<Transform>();
        Animator = gameObject.GetComponentInChildren<Animator>();
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

}
