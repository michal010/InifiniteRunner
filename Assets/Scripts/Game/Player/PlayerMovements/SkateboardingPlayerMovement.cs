using UnityEngine;

public class SkateboardingPlayerMovementData : ISkateboardingPlayerMovementDataProvider
{
    public IPlayer Player { get; private set; }
    public LevelBoundary LevelBoundary { get; private set; }
    public float ForwardMovementSpeed { get; private set; }
    public float SideMovementSpeed { get; private set; }

    public SkateboardingPlayerMovementData(IPlayer Player, LevelBoundary LevelBoundary, float ForwardMovementSpeed, float SideMovementSpeed)
    {
        this.Player = Player;
        this.LevelBoundary = LevelBoundary;
        this.ForwardMovementSpeed = ForwardMovementSpeed;
        this.SideMovementSpeed = SideMovementSpeed;
    }
}

public enum SkateboardingState { Run, Jump, Sliding}

public class SkateboardingPlayerMovement : BasePlayerMovement
{
    private ISkateboardingPlayerMovementDataProvider skateboardingDataProvider;

    public SkateboardingState state { get; private set; }

    public SkateboardingPlayerMovement(ISkateboardingPlayerMovementDataProvider skateboardingDataProvider) : base(skateboardingDataProvider)
    {
        this.skateboardingDataProvider = skateboardingDataProvider;
        state = SkateboardingState.Run;
    }

    

    public override void MovePlayer(Vector3 movementVector)
    {
        switch (state)
        {
            case SkateboardingState.Run:
                OnPlayerRun(movementVector);
                break;
            case SkateboardingState.Jump:
                OnPlayerJump();
                break;
            case SkateboardingState.Sliding:
                break;
        }
    }

    public override void OnCrouchButton()
    {

    }

    public override void OnJumpButton()
    {
        if(state == SkateboardingState.Run)
        {
            state = SkateboardingState.Jump;
            //Problem z tym, ¿e jednek klatki nie czeka i od razu przeskakuje jakby nie widzia³ tego stanu
            // trzeba jakoœ z-awaitowaæ to....
            // jakby siê uda³o jakoœ po prostu z monobehavioura playera odpaliæ, skoro it posiada de facto
            // t¹ klasê this.
            skateboardingDataProvider.Player.Animator.SetTrigger("Jump");
            skateboardingDataProvider.Player.Transform.gameObject.StartCoroutine();
            //Wait for frame...
        }
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private void OnPlayerJump()
    {
        if (isPlaying(skateboardingDataProvider.Player.Animator, "Skateboard Jump"))
        {
            // do nothing 
            Debug.Log("Still jumping");
        }
        else
        {
            state = SkateboardingState.Run;
        }
    }

    private void OnPlayerRun(Vector3 movementVector)
    {
        skateboardingDataProvider.Player.Transform.Translate(skateboardingDataProvider.Player.Transform.forward * Time.deltaTime * skateboardingDataProvider.ForwardMovementSpeed, Space.World);

        //  left movement
        if (movementVector.x < 0)
        {
            if (skateboardingDataProvider.Player.Transform.position.x > skateboardingDataProvider.LevelBoundary.LeftBoundary)
                skateboardingDataProvider.Player.Transform.Translate(skateboardingDataProvider.Player.Transform.right * Time.deltaTime * skateboardingDataProvider.SideMovementSpeed * movementVector.x);
        }
        if (movementVector.x > 0)
        {
            if (skateboardingDataProvider.Player.Transform.position.x < skateboardingDataProvider.LevelBoundary.RightBoundary)
                skateboardingDataProvider.Player.Transform.Translate(skateboardingDataProvider.Player.Transform.right * Time.deltaTime * skateboardingDataProvider.SideMovementSpeed * movementVector.x);
        }
    }
}
