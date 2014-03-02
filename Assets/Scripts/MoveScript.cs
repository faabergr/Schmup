using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 Speed = new Vector2(10, 10);
	public Vector2 Direction = new Vector2(-1, 0);

	private Vector2 _movement;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_movement = new Vector2(
			Direction.x * Speed.x, 
			Direction.y * Speed.y);
	}
	
	void FixedUpdate() {
		rigidbody2D.velocity = _movement;
	}
}
