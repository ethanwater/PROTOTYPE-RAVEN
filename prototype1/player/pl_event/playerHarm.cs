using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fn(inital_damage * (missing_health(bias) + 1))


public class playerHarm : MonoBehaviour {
	float harmRange = 0.5f;
	
	[Header("Environment")]
	float fireBaseDamagePerFrame = .037f;

	float DamageMultiplier(float baseDamage, float currentHealth, float bias) {
		float missingHealth = 1f - (currentHealth/100f);
		if (missingHealth == 0) {
			return baseDamage;
		} else {
			return baseDamage * ((missingHealth * bias)	+ 1f);
		}
	}
  void Update() {
		gameObject.TryGetComponent(out playerHealthSystem health);
		Collider[] colliderDeathArr = Physics.OverlapSphere(transform.position, harmRange);
		foreach (Collider collider in colliderDeathArr) {
			if (collider.TryGetComponent(out deathObjectTest death)) {
				health.playerHealth -= DamageMultiplier(fireBaseDamagePerFrame, health.playerHealth, 1f);
				death.Kill();
			}
		}    
  }
}
