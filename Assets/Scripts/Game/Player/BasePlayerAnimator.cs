using UnityEngine;

public interface IPlayerAnimator
{

}

public class BasePlayerAnimator : IPlayerAnimator
{
    public Animator animator { get; private set; }

    public BasePlayerAnimator(Animator animator)
    {
        this.animator = animator;
    }

    public void GetAnimationStateInfo()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }
}
