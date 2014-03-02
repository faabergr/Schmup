using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int CollisionDamage = 1; // How much to damage the player after collision

	private WeaponScript[] _weapons;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		_weapons = GetComponentsInChildren<WeaponScript> ();
	}

	// Update is called once per frame
	void Update () {
		foreach (var weapon in _weapons) {
			if (weapon != null && weapon.CanAttack) {
				weapon.Attack (true);
			}
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
