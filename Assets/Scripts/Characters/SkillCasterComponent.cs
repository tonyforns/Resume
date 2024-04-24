using UnityEngine;

internal class SkillCasterComponent : MonoBehaviour
{
    [SerializeField] private GameObject _skillPrefab;
    [SerializeField] private Transform _spawnPoint;

    public void CastSkill()
    {
        var skill = Instantiate(_skillPrefab);
        skill.transform.position = _spawnPoint.position;
        skill.transform.rotation = _spawnPoint.rotation;
    }
}