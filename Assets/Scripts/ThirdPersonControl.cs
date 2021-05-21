using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonControl : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public GameObject playerCameraController;

    public Rigidbody rb; //player

    public Vector3 cameraDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraDirection = playerCameraController.transform.TransformDirection(direction);
        cameraDirection.y = 0;

        rb.MovePosition(rb.position + (cameraDirection * speed * Time.deltaTime));
    }

    public void OnPlayerMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();

        direction.x = inputVector.x;
        direction.z = inputVector.y;

        direction.y = 0f;
    }
}
