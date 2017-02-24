using UnityEngine;
using System.Collections;

public class BulletA : MonoBehaviour {

	public float speed = 10f;
	public float damageAmount = 100f;
	public Vector3 target;
	public Vector3 direction;
	public GameObject player;
	public GameObject boundaryCollider;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
		target = player.transform.position;
		boundaryCollider = GameObject.Find ("ShotBoundry");
		direction = (target - this.transform.position).normalized;

	}
	
	// Update is called once per frame
	void Update () 
	{
		Fly ();
	}

	public void Fly()
	{
		this.transform.position +=  direction* speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject == player) 
		{
			other.gameObject.GetComponent<PlayerController> ().Damage (damageAmount);
			Destroy (this.gameObject);
		} 
		else 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == boundaryCollider) 
		{
			Destroy(this.gameObject);
			Debug.Log("Bullet Destroyed");
		}
	}
}
