using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public int damage = 20; 

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.isTrigger !=true && col.CompareTag ("Enemy"))
		{
			Destroy (gameObject); 

			col.SendMessageUpwards ("Damage", damage);

		}
	}
}
