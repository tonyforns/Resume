public class StartGameSceneController : BaseSceneController
{
    private IStartGameSceneView _view;

    public StartGameSceneController(IStartGameSceneView view)
    {
        _view = view;
        DialogueView.Instance.OnDialogueFinish += EndScene;
    }

    public void StartGame()
    {
        DialogueModel startGameDialogue = DataManager.Instance.GetStartGameDialogue();
        DialogueView.Instance.Show(startGameDialogue);
    }

    public void EndScene()
    {
        DialogueView.Instance.OnDialogueFinish -= EndScene;
        GameManager.Instance.LoadNextScene();
    }
}