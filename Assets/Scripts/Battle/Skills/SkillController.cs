using System;
using System.Collections.Generic;

public abstract class SkillController
{
    internal ISkillView _view;
    internal Stats _stats;

    public abstract void Act(Stats stats);

    public abstract void CharacterHit(ICharacterBattleView character);
}