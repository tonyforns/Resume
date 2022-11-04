using System;

public class GameManager : Singleton<GameManager>
{

    public Action OnSceneLoad;

    new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
