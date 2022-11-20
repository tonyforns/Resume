using UnityEngine;
using System.Collections;

public class StoryTellerSceneView : Singleton<StoryTellerSceneView>, IStoryTellerSceneView
{
    private StoryTellerSceneController _controller;
    new void Awake()
    {
        base.Awake();
        _controller = new StoryTellerSceneController(this);
    }
}
