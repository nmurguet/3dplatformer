using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoController : MonoBehaviour {
	public Rigidbody rb;

	public float moveSpeed; 

	public float jumpForce; 


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> (); 
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = (transform.forward * Input.GetAxisRaw ("Vertical")) + (transform.right * Input.GetAxisRaw ("Horizontal"));
		//rb.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,rb.velocity.y,Input.GetAxis("Vertical")*moveSpeed);

		if(Input.GetButton("Jump")){
			//Vector3 upwards = new Vector3 (0f, 1f*jumpForce, 0f);
			rb.AddForce (Vector3.up*jumpForce);
			//rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);

		}
	}
}
