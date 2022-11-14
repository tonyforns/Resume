using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class SkillAttackView : SkillView
{
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _controller = new SkillAttackController(this);
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward);
    }

    public override void Act(Stats stats)
    {
        _controller.Act(stats);
        transform.position += transform.forward * 1.2f; 
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        SetActive(false);
    }
}
