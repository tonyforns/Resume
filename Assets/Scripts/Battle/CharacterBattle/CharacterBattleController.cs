using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterBattleController
{
    internal ICharacterBattleView _view;
    internal CharacterModel _model;
    private int _currentLife;
    private Transform _enemyTransform;
    internal ISkillCasterView _skillCaster;

    public CharacterBattleController(ICharacterBattleView view, Transform enemyTransform, ISkillCasterView skillCaster)
    {
        _view = view;
        _enemyTransform = enemyTransform;
        _skillCaster = skillCaster;
    }

    public void StartBattle(CharacterModel model)
    {
        _model = model;
        _currentLife = _model.stats.life;
        _skillCaster.LoadSkills(model.skills);
        _view.SetCharacter(model.name, model.stats.lvl, _currentLife, model.prefab);
    }

    internal void CastSkill(string skillName)
    {
        BattleView.Instance.CharacterCastSkill(_model.name, skillName);
        _skillCaster.CastSkill(skillName, _model.stats, _view.GetTransform());
    }

    public void GetHit(int trueDamage)
    {
        int damage = ReduceDamage(trueDamage);
        BattleView.Instance.CharacterTakenBySkill(_model.name, damage.ToString());
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
        else
        {
            BattleView.Instance.SwitchTurn();
        }
    }

    public void OnFainted()
    {
        //BattleView.Instance.CharacterFaint(_view);
    }

    private int ReduceDamage(int trueDamage)
    {
        return trueDamage;
    }


}