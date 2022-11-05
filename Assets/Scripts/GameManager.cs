using System;

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
    }
}
