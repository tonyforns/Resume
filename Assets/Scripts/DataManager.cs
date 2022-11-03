using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public DialogueModel GetDialogue(int id)
    {
        return new DialogueModel();
    }
}
