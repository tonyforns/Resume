using UnityEngine;
using System.Collections;

public class SkillCasterView : MonoBehaviour, ISkillCasterView
{
    private SkillCasterController _controller;

    private void Awake()
    {
        _controller = new SkillCasterController(this);
    }

    public void CastSkill(string name, Stats stats, Transform position)
    {
        _controller.CastSkill(name, stats, position);
    }

    public ISkillView InstantiateSkill(SkillModel model)
    {
        return Instantiate(model.prefab, transform).GetComponent<SkillView>();
    }
}
