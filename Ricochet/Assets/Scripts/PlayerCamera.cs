using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerCamera : MonoBehaviour
{

    public float sensitivity;
    public float x;
    public float y;
    public DeltaControl delta;

    Transform xRotation;
    Vector2 lookInput;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Temp setup, see how the values work
        //x + delta.x;

        Debug.Log(delta);
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void HandleMouseLook()
    {
        //make own, euler is 3 inputs of rotation xyz. eq for z, mouse for xy, clamp y -89,89. clamp z -45,45. use deltacontrol (for mouse speed)
        
    }

}
