using UnityEngine;

public class WishButton : MonoBehaviour
{
    public void CompleteWish()
    {
        if(WishManager.Instance != null)
        {
            WishManager.Instance.CompletedWish();
        }
        else
        {
            Debug.LogError("WishManager not found!");
        }
    }
}
//when certain button is pressed, CompletedWishes++ (from script WishManager)