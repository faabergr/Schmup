using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform ShotPrefab;
	public float ShootingRate = 0.25f;
	public bool CanAttack
	{
		get { return shootCooldown <= 0f; }
	}
	public AudioClip ShootSound;

	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shootCooldown = ShootingRate;

			if (ShootSound != null) {
				audio.PlayOneShot(ShootSound);
			}

			var shotTransform = Instantiate (ShotPrefab) as Transform;
			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
			if (shot != null) {
					shot.IsEnemyShot = isEnemy;
			}

			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();
			if (move != null) {
				move.Direction = this.transform.right;
			}
		}
	}
}
