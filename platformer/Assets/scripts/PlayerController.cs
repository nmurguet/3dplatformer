using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; 
	//public Rigidbody rb; 
	public float jumpForce; 

	public CharacterController controller; 

	private Vector3 moveDirection; 
	public float gravityScale; 

	public Animator anim; 

	// Use this for initialization
	void Start () {
	//	rb = GetComponent<Rigidbody> (); 
		controller = GetComponent<CharacterController>(); 

	}
	
	// Update is called once per frame
	void Update () {
		/*
		rb.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,rb.velocity.y,Input.GetAxis("Vertical")*moveSpeed);

		if(Input.GetButtonDown("Jump")){
			rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);

		}
		*/


		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxisRaw ("Vertical") ) + (transform.right * Input.GetAxisRaw("Horizontal"));
		moveDirection = moveDirection.normalized * moveSpeed; //aplico la gravedad de vuelta porque lo normalice y anda lento
		moveDirection.y = yStore; 


		if (controller.isGrounded ) {
			//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, 0f, Input.GetAxis ("Vertical") * moveSpeed); esto lo que hace es que no se pueda mover en el aire
			moveDirection.y = 0f; 
			if (Input.GetButtonDown ("Jump")) {
				moveDirection.y = jumpForce;

			}
		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale*Time.deltaTime);

		controller.Move (moveDirection * Time.deltaTime);

		anim.SetBool ("isGrounded", controller.isGrounded);
		anim.SetFloat ("Speed", (Mathf.Abs (Input.GetAxis ("Vertical"))+Mathf.Abs(Input.GetAxis("Horizontal"))));
		
	}
}
