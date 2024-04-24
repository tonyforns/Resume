using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject viewsParent;
    [SerializeField] private Dictionary<string, GameObject> viewsDictionary = new();
    private string currentViewName = "StartResume";
    public Action OnSceneLoad;

    new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        foreach (Transform view in viewsParent.transform) 
        {
            viewsDictionary.Add(view.gameObject.name, view.gameObject);
            view.gameObject.SetActive(false);
        }
        viewsParent.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LoadNextScene()
    {
        DialogueView.Instance.OnDialogueFinish = null;
        string nextScene = DataManager.Instance.GetNextScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNextView()
    {
        DialogueView.Instance.OnDialogueFinish = null;
        GameObject currentView;
        viewsDictionary.TryGetValue(currentViewName, out currentView);
        currentView.SetActive(false);
        string nextScene = DataManager.Instance.GetNextView(currentViewName);
        viewsDictionary.TryGetValue(nextScene, out currentView);
        currentView.SetActive(true);
        currentViewName = currentView.name;
    }

    public void QuitResume()
    {
        Application.Quit();
    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            QuitResume();
        }
    }
}
