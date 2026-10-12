using UnityEngine;

public class SceneTransfer : MonoBehaviour
{
    private bool playerNearby = false;
    public GameObject leaveCanvas;

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
            Debug.Log("You can open the door");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            Debug.Log("Away from door");
        }
    }

    void Interact()
    {
        Debug.Log("Leave or not?");
        leaveCanvas.SetActive(true); //if player is close to door and press ENTER, display canvas.
    }
}
