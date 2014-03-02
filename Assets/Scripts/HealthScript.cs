using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
	public int HealthPoints = 1;
	public bool IsEnemy = true;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void Damage (int damageCount)
	{
			HealthPoints -= damageCount;

			if (HealthPoints <= 0) {
				Destroy (gameObject);
			}
	}

	void OnTriggerEnter2D (Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) {
			if (shot.IsEnemyShot != IsEnemy) {
				Damage (shot.Damage);
				 
				// Destroy the shot
				Destroy (shot.gameObject);
			}
		}
	}
}
