using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public partial class PlayerController
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private CharacterController charController;


}
public partial class PlayerController : MonoBehaviour
{
    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleMovement();
    }
    private void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        charController.SimpleMove(forward * curSpeed);
    }

    private void HandleRotation()
    {
        float moveX = Input.GetAxis("Horizontal");


        transform.Rotate(moveX * Vector3.up);

    }
}
