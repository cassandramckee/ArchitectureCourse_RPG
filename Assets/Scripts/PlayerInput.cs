using System;
using UnityEngine;

public class PlayerInput : IPlayerInput
{
    public event Action<int> HotkeyPressed;
    public event Action MoveModeTogglePressed;

    // Note: Unity's new input system probably takes care of a bunch of this
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");
    public float MouseX => Input.GetAxis("Mouse X");


    public void Tick()
    {
        if (MoveModeTogglePressed != null && Input.GetKeyDown(KeyCode.Minus))
            MoveModeTogglePressed();
        
        // Short circuit if no HotKeyDown event registered
        if (HotkeyPressed == null)
            return;

        // For each of the numbered keys
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                HotkeyPressed(i);
            }
        }
    }
}