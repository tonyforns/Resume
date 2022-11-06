public class StartGameSceneController : BaseSceneController
{
    private IStartGameSceneView _view;

    public StartGameSceneController(IStartGameSceneView view)
    {
        _view = view;
        DialogueView.Instance.OnDialogueFinish += EndScene;
        DialogueView.Instance.Hide();
    }

    public void StartGame()
    {
        DialogueView.Instance.Show(DataManager.Instance.GetStartGameDialogueId());
    }

    public void EndScene()
    {
        DialogueView.Instance.OnDialogueFinish -= EndScene;
        GameManager.Instance.LoadNextScene();
    }
}