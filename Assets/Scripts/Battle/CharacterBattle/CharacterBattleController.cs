using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterBattleController
{
    internal ICharacterBattleView _view;
    internal CharacterModel _model;
    private int _currentLife;
    private Transform _enemyTransform;

    private Dictionary<string, SkillModel> _skills;

    public CharacterBattleController(ICharacterBattleView view, Transform enemyTransform)
    {
        _view = view;
        _enemyTransform = enemyTransform;
    }

    public void StartBattle(CharacterModel model)
    {
        _model = model;
        _currentLife = _model.stats.life;
        GenerateAbilitiesDictionary();
        var abilitesName = _skills.Keys.ToList();
        _view.SetCharacter(model.name, model.stats.lvl, _currentLife, model.prefab, abilitesName);
    }

    public void GetHit(int trueDamage)
    {
        int damage = ReduceDamage(trueDamage);
        _currentLife = (_currentLife - damage) <= 0 ? 0 : _currentLife - damage;
        _view.UpdateLife(_currentLife);
    }

    public void SkillTaken(int trueDamage, string type) //Skill q lo afecta con el tipo de efecto que le hace (danio, heal, trudamage, shield)
    {
        
    }

    public void OnLifeUpdated()
    {
        if(_currentLife == 0)
        {
            _view.Faint();
        }
        //BattleView.Instance.CharacterReady(_model);
    }

    public void OnFainted()
    {
        //BattleView.Instance.CharacterFaint(_view);
    }

    private void GenerateAbilitiesDictionary()
    {
        foreach (SkillModel abilitie in _model.skills.List())
        {
            _skills.Add(abilitie.name, abilitie);
        }
    }

    private int ReduceDamage(int trueDamage)
    {
        return trueDamage;
    }

    internal void CastSkill(SkillView skillView)
    {
        skillView.Act(_model.stats);
    }
}