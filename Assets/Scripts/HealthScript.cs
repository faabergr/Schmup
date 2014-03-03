using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
	public int HealthPoints = 1;
	public bool IsEnemy = true;
    public AudioClip DeathSound;

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

		Debug.Log (string.Format ("{0} health: {1}", gameObject.name, HealthPoints));

		if (HealthPoints <= 0) {
			Destroy (gameObject);
            if (gameObject.audio != null) gameObject.audio.PlayOneShot(DeathSound);
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
