using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public partial class PlayerController
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 3f;
    [SerializeField] private CharacterController charController;
}
public partial class PlayerController : MonoBehaviour
{
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleMovement();
        HandleAttack();
    }
    private void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        animator.SetFloat("Speed", curSpeed);
        charController.SimpleMove(forward * curSpeed);
    }

    private void HandleAttack()
    {
        animator.SetBool("Attack", Input.GetButtonDown("Fire1")); ;
    }
    private void HandleRotation()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Rotate(moveX * Vector3.up);

    }
}
