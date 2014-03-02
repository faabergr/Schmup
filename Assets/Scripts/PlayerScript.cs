using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 Speed = new Vector2(50, 50);

	private Vector2 _movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		_movement = new Vector2(inputX * Speed.x, inputY * Speed.y);

		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null) {
				weapon.Attack(false);
			}
		}
	}

	void FixedUpdate() {
		rigidbody2D.velocity = _movement;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript> ();
		if (enemy != null) {
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.HealthPoints);

			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(enemy.CollisionDamage);
		}
	}
}
