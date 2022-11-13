using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class CharacterBattleView : MonoBehaviour, ICharacterBattleView
{
    internal CharacterBattleController _controller;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _lvl;
    [SerializeField] private TextMeshProUGUI _life;
    [SerializeField] private Slider _lifeSlider;
    [SerializeField] internal Transform _enemyTransform;
    [SerializeField] 
    private int _maxLife = 100;
    private GameObject _model;

    private void Awake()
    {
        _controller = new CharacterBattleController(this, _enemyTransform);
    }

    public void SetCharacter(string name, int lvl, int maxLife, GameObject prefab, List<string> abilities)
    {
        _name.text = name;
        SetLvl(lvl);
        _maxLife = maxLife;
        SetLife(maxLife);
        if (_model) Destroy(_model);
        _model = Instantiate(prefab, transform);
    }

    private void SetLvl(int lvl)
    {
        _lvl.text = $"lvl {lvl}";
    }

    private void SetLife(int value)
    {
        _life.text = $"{value}/{_maxLife}";
        _lifeSlider.value = value / _maxLife;
    }

    public void UpdateLife(int newValue)
    {
        SetLife(newValue);
        _controller.OnLifeUpdated();
    }

    public void StartBattle(CharacterModel model)
    {
        _controller.StartBattle(model);
    }

    public void Hited(int damage)
    {
        _controller.GetHit(damage);
    }

    public void MakeAbility(string name)
    {
        throw new System.NotImplementedException();
    }

    public void SetDebuff()
    {
        throw new System.NotImplementedException();
    }

    public void Faint()
    {
        Destroy(_model);
        _controller.OnFainted();
    }

    public void EnableTurn()
    {
        throw new System.NotImplementedException();
    }

    public void CastSkill(SkillModel skill)
    {
        GameObject skillGO = Instantiate(skill.prefab, transform);
        _controller.CastSkill(skillGO.GetComponent<SkillView>());
    }
}
