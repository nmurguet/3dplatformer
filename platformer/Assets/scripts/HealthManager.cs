using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
	public int maxHealth; 

	public int currentHealth; 

	public PlayerController player; 

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth; 
		player = FindObjectOfType<PlayerController> (); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void HurtPlayer(int damage, Vector3 direction)
	{
		currentHealth -= damage; 
		player.KnockBack (direction); 



	}

	public void HealPlayer(int healAmount)
	{
		currentHealth += healAmount; 

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth; 

		}

	}
}
