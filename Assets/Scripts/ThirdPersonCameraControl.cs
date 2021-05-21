using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraControl : MonoBehaviour
{
    public GameObject playerCamera;

    public float deltaX;
    public float deltaY;

    [Header("Mouse Sensitivity 0-1")]
    public float ms;

    public float xRot;
    public float yRot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //hide the cursor

    }
    
    // Update is called once per frame
    void Update()
    {


        yRot += deltaX * ms;
        xRot -= deltaY * ms;

        xRot = Mathf.Clamp(xRot, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        //playerCamera.transform.rotation = Quaternion.Euler(0, yRot, 0);

    }


    public void OnCameraLook(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }


}

