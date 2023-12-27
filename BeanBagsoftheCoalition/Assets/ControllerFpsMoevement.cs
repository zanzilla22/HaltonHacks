using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFpsMoevement : MonoBehaviour
{
    public float moveSpeed;
    private CharacterController _controller;
    void Start()
    {
        _controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _controller.Move(move * Time.deltaTime * moveSpeed);
        if (Input.GetAxisRaw("RightTrigger") != 0)
            Debug.Log("Shoot");
    }
}
