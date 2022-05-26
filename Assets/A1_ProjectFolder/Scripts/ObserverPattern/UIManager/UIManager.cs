public class UIManager : Manager
{
    public static UIManager instance;
    public UITaskOfficers UITaskOfficers;
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
}
