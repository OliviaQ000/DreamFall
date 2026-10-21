using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    //collider is not triggered to start dialogue again when certain dialogue is finished
    public Collider targetCollider;

    public void DisableTrigger()
    {
        if (targetCollider != null)
        {
            targetCollider.isTrigger = false;
        }
    }
    //collider is triggered to start dialogue again when certain dialogue is finished
    public void EnableTrigger()
    {
        if (targetCollider != null)
        {
            targetCollider.isTrigger = true;
        }
    }

}
