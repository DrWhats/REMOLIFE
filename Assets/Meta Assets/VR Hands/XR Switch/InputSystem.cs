using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class InputSystem : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity __Inspector__ window

    void Start()
    {
        watcher.primaryButtonPress.AddListener(OnPrimaryButtonEvent);
    }

    public void OnPrimaryButtonEvent(bool pressed)
    {
        if (pressed)
            Debug.Log("Primary button pressed");
        if (!pressed)
            Debug.Log("Primary button released");
    }
    
}
