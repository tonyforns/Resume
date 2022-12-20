using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    [SerializeField] private CharacterList _characterList;

    new void Awake()
    {
        base.Awake();
    }

    public DialogueModel GetDialogue(int id)
    {
        switch (id)
        {
            case 1:
                return new DialogueModel(1, "El mensaje que se va a mostrar", 1, new DialogueModel(11, "El mensaje que se va a mostrar en segunda parte", 2,
                    new DialogueModel(111, "El mensaje que se va a mostrar tercero", 3, null))) ;
            case 2:
                return new DialogueModel(2, "El mensaje Del 1", 1, null);
            case 3:
                return new DialogueModel(3, "El mensaje del 2", 2, null);
            case 4:
                return new DialogueModel(4, "El mensaje del 3", 3, null);
            default:
                return new DialogueModel(1, "Caso base", 4, null);
        }
    }

    internal string GetNextView(string name)
    {
        Debug.Log(name);
        switch (name)
        {
            case "StartResume":
                return "CharacterSelection";
            default:
                return "StartResume";
        }
    }

    public string GetNextScene(string name)
    {
        switch (name)
        {
            case "StartResume":
                return "CharacterSelection";
            default:
                return "StartResume";
        }
    }

    public int GetStartGameDialogueId()
    {
        return 1;
    }

    public Dictionary<int, CharacterModel> GetCharacterIdToModelDiccionary()
    {
        var diccionary = new Dictionary<int, CharacterModel>();
        foreach (CharacterModel model in _characterList.List())
        {
            diccionary.Add(model.id, model);
        }
        return diccionary;
    }

    public CharacterList GetCharacterList()
    {
        return _characterList;
    }

    public Dictionary<int, int> GetCharacterSelectionDialogues()
    {
        var dialogues = new Dictionary<int, int>();
        dialogues.Add(1, 2);
        dialogues.Add(2, 3);
        dialogues.Add(3, 4);
        return dialogues;
    }
}
