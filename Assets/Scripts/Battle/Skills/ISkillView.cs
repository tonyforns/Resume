using UnityEngine;

public interface ISkillView
{
    public void Act(Stats stats);
    public void SetPosition(Transform position);
    public void SetActive(bool isActive);
}