using Sirenix.OdinInspector;

public class GameManager : SerializedMonoBehaviour
{
    public static GameManager instance;
    public GameManagerObserverOfficer gameManagerObserverOfficer;

    private void Awake()
    {
        StaticCheck();
        
        gameManagerObserverOfficer.CreateSubjects();
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
