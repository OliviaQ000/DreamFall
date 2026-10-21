using UnityEngine;
using DialogueEditor;

public class Item_Collection : MonoBehaviour
{
    public NPCConversation myConversation;   //assign individual conversations via the inspector
    private bool playerNearby = false;

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
            Debug.Log("You can pick up item!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            Debug.Log("Away from item");
        }
    }

    void Interact()
    {
        Debug.Log("Conversation Start!");
        ConversationManager.Instance.StartConversation(myConversation);  //if player is close to item and press ENTER, start conversation
    }
}
