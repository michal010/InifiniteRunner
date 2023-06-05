using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMovementInput
{
    Vector2 MovementInputVector { get; }
    public UnityEvent OnCrouchButton { get; }
    public UnityEvent OnJumpButton { get; }
}

public class PlayerInput : IMovementInput
{
    public Vector2 MovementInputVector { get; private set; }

    [Range(0, 1)]
    [Tooltip("Range of mouse motion from the center of the screen in % value")]
    public float OuterDeadZonePercentage = 0.5f;

    [Range(0, 1)]
    [Tooltip("Dead zone of mouse motion - % value of mouse movement that will be ignored from the center of the screen.")]
    public float InnerDeadZonePercentage = 0.1f;

    public UnityEvent OnCrouchButton { get; private set; }
    public UnityEvent OnJumpButton { get; private set; }

    private float halfScreenWidth = Screen.width / 2f;
    private float innerDeadZone;
    private float outerDeadZone;
    private float motionZone;

    public PlayerInput()
    {
        // Inner dead zone in px
        innerDeadZone = Screen.width * InnerDeadZonePercentage;
        // Outer dead zone in px
        outerDeadZone = Screen.width * OuterDeadZonePercentage;
        // Range of motion in pixels
        motionZone = halfScreenWidth - innerDeadZone / 2f - outerDeadZone / 2f;
        // Initialize events
        OnCrouchButton = new UnityEvent();
        OnJumpButton = new UnityEvent();
    }

    public void GetButtonInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnCrouchButton.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnJumpButton.Invoke();
        }    
    }

    public void GetMovementInput()
    {
        // X of mouse calculated from center of the screen.
        float mouseXraw = Input.mousePosition.x - halfScreenWidth;
        float x = 0f;
        // If inside inner dead zone, x = 0
        if (Mathf.Abs(mouseXraw) < innerDeadZone / 2f)
            x = 0;
        // If outside outer dead zone, x = 1 or x = -1
        else if (Mathf.Abs(mouseXraw) > outerDeadZone / 2f)
            x = Mathf.Sign(mouseXraw);
        // Else calculate x in relation to motion zone.
        else
        {
            float xRelatedToMotionZone = (Mathf.Abs(mouseXraw) - (innerDeadZone / 2f)) / motionZone;
            x = Mathf.Sign(mouseXraw) * Mathf.Clamp01(xRelatedToMotionZone);
        }
        MovementInputVector = new Vector2(x, 0);
    }
}
