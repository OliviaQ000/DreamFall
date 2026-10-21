using UnityEngine;

public class Dialogue_SwichManager : MonoBehaviour
{
    // when multiple conversation is attached to same game object, disable the first conversation, enable the second(following) conversation
    public Behaviour scriptToEnable;
    public Behaviour scriptToDisable;

    public void SwitchScripts()
    {
        if (scriptToEnable != null)
        {
            scriptToEnable.enabled = true;
        }

        if (scriptToDisable != null)
        {
            scriptToDisable.enabled = false;
        }

            
    }

   
}
