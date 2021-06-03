using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    public GameObject focusedObject;

    public GameObject pickupSlot;

    public float interactDistance;

    public bool holding;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (holding)
        {
            return;


        }


        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        Ray ray = new Ray(transform.position, fwd);

        if(Physics.Raycast(ray, out hit))
        {
            focusedObject = hit.collider.gameObject;


        }
        else
        {
            focusedObject = null;
        }


    }

    public void OnInteract()
    {
        if(holding)
        {
            focusedObject.transform.parent = null;
            focusedObject.GetComponent<Rigidbody>().isKinematic = false;
            holding = false;
        }
        else if (focusedObject.CompareTag("Interactable"))
        {
            focusedObject.transform.parent = pickupSlot.transform;
            focusedObject.transform.position = pickupSlot.transform.position;
            focusedObject.GetComponent<Rigidbody>().isKinematic = true;
            holding = true;



        }

    }
}
