using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Awake()
    {
        offset = transform.position - target.position;     
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
                    target.position + offset, Time.deltaTime * 5);             //using lerp (move soomthly from point to point) to make the camera follow the player
    }
}
