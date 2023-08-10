using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthSystem : MonoBehaviour
{
	public float playerHealthMax = 100f;
	public float playerHealth;
	public bool aliveStatus;
	
	private void DeathCheck() {
		if(playerHealth <= 0){
			aliveStatus = false;
		}
	}

  private void Start()
  {
		playerHealth = 100f;
    aliveStatus = true;
  }

  private void Update()
  {
    DeathCheck(); 
  }
}
