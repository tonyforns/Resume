using UnityEngine;
using System.Collections;

public class StartGameSceneView : Singleton<StartGameSceneView>, IStartGameSceneView
{
    private StartGameSceneController _controller;

    new void Awake()
    {
        base.Awake();
        _controller = new StartGameSceneController(this);
    }

    public void StartGame()
    {
        _controller.StartGame();
    }
}
