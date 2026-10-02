using UnityEngine;

public class Player_MoveControl : MonoBehaviour
{
    public float speed = 1;
    public Animator animator;
    Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!animator)
        {
            animator = GetComponentInChildren<Animator>();
        }
        _rb = GetComponent<Rigidbody>();                     //If there is no animator at the beginning, find one from child object("PlayerBody") and find the rigid body ("Player")
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        _rb.linearVelocity = new Vector3 (h, 0, v) * speed;       // for walking in 3D world, use X and Z axis is enough (no jumping in this game hence y=0)  
        animator.SetBool("Move", h !=0 || v != 0);          // play animation of player moving when x or z is not 0
        if (h != 0)
        {
            animator.transform.localScale = new Vector3(Mathf.Sign(h), 1, 1);     //let player face to the same direction as they are moving (turn left or right)
        }
    }

}
