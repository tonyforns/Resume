using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Action OnSceneLoad;

    new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextScene()
    {
        DialogueView.Instance.OnDialogueFinish = null;
        string nextScene = DataManager.Instance.GetNextScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(nextScene);
    }
}
