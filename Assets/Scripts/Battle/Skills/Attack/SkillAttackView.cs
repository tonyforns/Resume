using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class SkillAttackView : SkillView
{
    private void Awake()
    {
        _controller = new SkillAttackController(this);
    }
    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward);

    }

    public override void Act(Stats stats)
    {
        _controller.Act(stats);
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
