using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCamera : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        this.GetComponent<Camera>().rect = mainCamera.rect;
    }
}
