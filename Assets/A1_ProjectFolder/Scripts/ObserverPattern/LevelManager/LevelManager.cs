public class LevelManager : Manager
{
    public static LevelManager instance;
    public LevelCreateOfficer LevelCreateOfficer;

    private void Awake()
    {
        StaticCheck();
    }
    
    void StaticCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public override void PreLevelInstantiateProcess()
    {
        StartCoroutine(LevelCreateOfficer.SceneTransitionProcess());
    }

    public override void LevelInstantiateProcess()
    {
        LevelCreateOfficer.CreateTheLevel();
    }

    public override void PostLevelInstantiateProcess()
    {
        GameManager.instance.currentGameState = GameStates.InGame;
    }
}
