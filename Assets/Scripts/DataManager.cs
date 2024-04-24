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
            case 99:
                
                 return new DialogueModel(99, "Welcome to my Master's Resume! Be aware, nothing is what it seems. He have a dangerous and dark story... ", 3,
                    new DialogueModel(11, "Shut up! Do not continue talking, it will be our downfall!", 4,
                    new DialogueModel(111, "Maybe they can help us!", 3,
                    new DialogueModel(111, "Help them? NEVER!", 8,
                    new DialogueModel(111, "If you got here, surely you want to know about me.. or so you pretend", 8,
                    new DialogueModel(111, "I am a 29 year old boy born in Salta Argentina who has been passionate about video games since I was a child...", 8,
                    new DialogueModel(111, "All those stories and worlds that can be created!", 8,
                    new DialogueModel(111, "Where your only limit is your imagination... For this passion I decided to study something that would allow me to create them.", 8,
                    new DialogueModel(111, "I studied and graduated as a Computer Engineer in 5 years", 8,
                    new DialogueModel(111, "I worked for a year at Sovos, developing internal testing tools and performance metrics.", 8,
                    new DialogueModel(111, "Then I changed my job and for 3 years I developed Casino's games, especially Slots.", 8,
                    new DialogueModel(111, "My outstanding knowledges are the following!", 8, null)
                    )))))))))));
            case 1:
                return new DialogueModel(1, "Unity3D Intermediate", 1, new DialogueModel(1, "Development of 3 slot games from prototyping, art design, mechanics, resource optimization and publication. Aymara, Aliens & Fruits and Aymara Casino.", 1, new DialogueModel(3, "Knowledge in Particles System", 1, null)));
            case 2:
                return new DialogueModel(2, "C# Intermediate", 2, new DialogueModel(2, "C# Applied to development with Unity", 2, null));
            case 3:
                return new DialogueModel(3, "Phaser 2/3 Intermediate", 3,  new DialogueModel(3, "Development of 4 Slots games from prototyping, art design, mechanics, resource optimization and publication.", 3, new DialogueModel(3, "Games: Aymara, Aliens & Fruits, Dragon's Chest and Magic Relics", 3, null)));
            case 4:
                return new DialogueModel(4, "JavaScript Intermediate", 4, new DialogueModel(4, "JavaScript applied to development with Phaser 2 and Phaser 3", 4, null));
            case 5:
                return new DialogueModel(5, "MySQL Basic", 5, new DialogueModel(2, "Knowledge of relational database, views and store procedures", 5, null));
            case 6:
                return new DialogueModel(6, "Scrum Intermediate", 6, new DialogueModel(2, "Work with Agile Methodology for 1 year", 6, null));
            case 7:
                return new DialogueModel(7, "Git Intermediate", 7, new DialogueModel(2, "Development of all projects using the versioning tool for project management ", 7, null));
            case 8:
                return new DialogueModel(7, "Just me", 8, new DialogueModel(2, "A simple developer with an aspiration to be able to be part of the creation of a virtual world of adventures. Lover of challenges and predisposed to learn.", 8, null));
            default:
                return new DialogueModel(5, "default", 5, null);
        }
    }

    
    public string GetNextView(string name)
    {
        Debug.Log(name);
        switch (name)
        {
            case "StartResume":
                return "CharacterSelection";
            case "CharacterSelection":
                return "WorldAdventure";
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
        return 99;
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

    public int GetAllowCharacterSelectionId()
    {
        return -8;
    }

    public Dictionary<int, int> GetCharacterSelectionDialogues()
    {
        var dialogues = new Dictionary<int, int>();
        dialogues.Add(1, 1);
        dialogues.Add(2, 2);
        dialogues.Add(3, 3);
        dialogues.Add(4, 4);
        dialogues.Add(5, 5);
        dialogues.Add(6, 6);
        dialogues.Add(7, 7);
        dialogues.Add(8, 8);
        return dialogues;
    }
}
