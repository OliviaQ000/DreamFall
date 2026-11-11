using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene

public class WishManager : MonoBehaviour
{
    public static WishManager Instance {get; private set;} //other scripts can read but cannot change the value
    [SerializeField] private int totalCharacters = 3;
    public int CompletedWishes {get; private set;} = 0;

    private void Awake()
    {
        if(Instance != null && Instance != this) //Check if there is only one manager
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); //still exist when load a new scene
    }

    public void CompletedWish()
    {
        CompletedWishes++;
        Debug.Log("Completed Wishes:" + CompletedWishes + "/" + totalCharacters);
    }

    public string GetEnding() 
    {
        if (CompletedWishes > totalCharacters / 2f) //if more than half of the wishes is fullfilled, good ending
            return"Good";

        if (CompletedWishes < totalCharacters / 2f)
            return"Bad";

        return "Normal";
    }

    public void LoadEndingScene()
    {
        string ending = GetEnding();

        if (ending == "Good")
        {
            SceneManager.LoadScene("GoodEnding");
        }
        
        else if (ending == "Bad")
        {
            SceneManager.LoadScene("BadEnding");
        }

        else
        {
            SceneManager.LoadScene("NormalEnding");
        }
    }
}
