using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    // Config
    [SerializeField] float runSpeed =5f;
    [SerializeField] float jumpForce = 5f;

    // State
    bool isAlive = true;

    //Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myCollider2D;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
	}
	
	// message then methods
	void Update () {
        FlipSprite();
        Run();
        Jump();
	}

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");  // -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        myAnimator.SetBool("Running", Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon);
    }

    private void Jump()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump") && myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);            
        }
    }
}
