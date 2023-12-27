using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerLook : MonoBehaviour
{
    public InputAction rightStick;
    public float controllerSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void OnEnable()
    {
        rightStick.Enable();
    }
    void OnDisable()
    {
        rightStick.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float controllerX = rightStick.ReadValue<Vector2>().x * controllerSensitivity * Time.deltaTime;
        float controllerY = rightStick.ReadValue<Vector2>().y * controllerSensitivity * Time.deltaTime;

        Debug.Log("X = " + rightStick.ReadValue<Vector2>().x + " - Y = " + rightStick.ReadValue<Vector2>().y);

        xRotation -= controllerY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * controllerX);
    }
}
