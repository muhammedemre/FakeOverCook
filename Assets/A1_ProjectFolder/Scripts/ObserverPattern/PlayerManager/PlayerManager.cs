public class PlayerManager : Manager
{
    public static PlayerManager instance;

    public PlayerPointsOfficer playerPointsOfficer;
    
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

    public override void PostLevelInstantiateProcess()
    {
        playerPointsOfficer.PrepareValues();
    }
}
