using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class SkillView : MonoBehaviour , ISkillView
{
    [SerializeField] internal SkillController _controller;

    public abstract void Act(Stats stats);

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetPosition(Transform position)
    {
        transform.SetPositionAndRotation(position.position, position.rotation);
    }

    public void OnCollisionEnter(Collision collision)
    {
        ICharacterBattleView character = collision.gameObject.GetComponent<ICharacterBattleView>();
        _controller.CharacterHit(character);
    }
}