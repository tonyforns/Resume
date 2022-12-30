using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public partial class PlayerController
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 3f;
    [SerializeField] private CharacterController charController;
    [SerializeField] private float _attackCountDown = ATTACK_COUNT_DOWN;
    [SerializeField] private const float ATTACK_COUNT_DOWN = 1.5f;
}
public partial class PlayerController : MonoBehaviour
{
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        DialogueView.Instance.OnDialogueStart += DisablePlayer;
        DialogueView.Instance.OnDialogueFinish += EnablePlayer;
    }

    public void OnDestroy()
    {
        DialogueView.Instance.OnDialogueStart -= DisablePlayer;
        DialogueView.Instance.OnDialogueFinish -= EnablePlayer;
    }
    public void DisablePlayer()
    {
        enabled = false;
    }

    public void EnablePlayer()
    {
        enabled = true;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (DialogueView.Instance.IsDialogueActive()) return;
        HandleRotation();
        HandleMovement();
        HandleAttack();
    }
    private void HandleMovement()
    {
        if(IsAttacking())
        {
            animator.SetBool("IsMoving", false);
            SoundManager.Instance.PlayPlayerWalking(false);
            return;
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        animator.SetBool("IsMoving", Input.GetAxis("Vertical") != 0);
        SoundManager.Instance.PlayPlayerWalking(Input.GetAxis("Vertical") != 0);
        charController.SimpleMove(forward * curSpeed);
    }

    private void HandleAttack()
    {
        _attackCountDown += Time.deltaTime;
        if (Input.GetButtonUp("Fire1") && !IsAttacking())
        {
            _attackCountDown = 0;
           SoundManager.Instance.PlayPlayerWeaponAttack();
           animator.SetTrigger("Attack");
        }
    }

    private bool IsAttacking()
    {
        return _attackCountDown < ATTACK_COUNT_DOWN;
    }
    private void HandleRotation()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Rotate(moveX * Vector3.up);

    }
}
