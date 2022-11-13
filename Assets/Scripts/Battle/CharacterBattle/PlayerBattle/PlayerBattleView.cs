using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBattleView : CharacterBattleView
{
    [SerializeField] private IBattleSkillBarView _skillBar;

    private void Awake()
    {
        _controller = new PlayerBattleController(this, _enemyTransform, _skillBar);
    }

}
