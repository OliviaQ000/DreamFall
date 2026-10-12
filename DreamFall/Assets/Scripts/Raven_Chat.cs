using UnityEngine;
using DialogueEditor;

public class Raven_Chat : MonoBehaviour
{
    public NPCConversation myConversation;   //assign individual conversations via the inspector
    private bool playerNearby = false;
    public GameObject chatIcon;

    void Update()
    {
        if(playerNearby && Input.GetKeyDown(KeyCode.Return))
        {
            Interact();
        }
    }   

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerNearby = true;
            chatIcon.SetActive(true);    //Let ChatIcon appear when player is close to NPC
            Debug.Log("You can start Conversation!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            chatIcon.SetActive(false);
            Debug.Log("Away from NPC");
        }
    }

    void Interact()
    {
        Debug.Log("Conversation Start!");
        ConversationManager.Instance.StartConversation(myConversation);  //if player is close to NPC and press ENTER, start conversation
    }
}
