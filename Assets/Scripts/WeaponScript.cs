using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform ShotPrefab;
	public float ShootingRate = 0.25f;
	public bool CanAttack
	{
		get { return shootCooldown <= 0f; }
	}

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

			Vector3 playerSize = renderer.bounds.size;

			var shotTransform = Instantiate(ShotPrefab) as Transform;
			shotTransform.position = new Vector3(gameObject.transform.position.x + (playerSize.x / 2.0f), 
			                                     transform.position.y, 
			                                     transform.position.z);

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null) {
				shot.IsEnemyShot = isEnemy;
			}

			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) {
				move.Direction = this.transform.right;
			}
		}
	}
}
