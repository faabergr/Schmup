using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int Damage = 1;
	public bool IsEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20); // destroy after 20 seconds to avoid leak
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible() {
		//Destroy (gameObject);
	}
}
