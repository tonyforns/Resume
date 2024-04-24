using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterModel
{
    public int id;
    public GameObject prefab;
    public string name;
    public string description;
    public Stats stats;
    public SkillList skills;
}
