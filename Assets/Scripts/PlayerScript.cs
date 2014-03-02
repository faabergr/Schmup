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

		Debug.Log (string.Format ("Update movement: x: {0}, y: {1}", _movement.x, _movement.y));

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
		Debug.Log (string.Format ("Fixed Update movement: x: {0}, y: {1}", _movement.x, _movement.y));
		rigidbody2D.velocity = _movement;
	}
}
