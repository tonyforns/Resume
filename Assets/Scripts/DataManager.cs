using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    new void Awake()
    {
        base.Awake();
    }

    public DialogueModel GetDialogue(int id)
    {
        return new DialogueModel();
    }

    public CharacterList GetCharacterList()
    {
        return null;
    }

    public Dictionary<int, int> GetCharacterSelectionDialogues()
    {
        return new Dictionary<int, int>();
    }
}
