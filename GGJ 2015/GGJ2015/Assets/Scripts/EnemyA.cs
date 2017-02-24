using UnityEngine;
using System.Collections;

public class EnemyA : MonoBehaviour {

	public GameObject player;
	public GameObject bullet;

	public float time = 4f;
	public float throwTime = 3f;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		bullet = Resources.Load("BulletA") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerStay2D(Collider2D other) 
	{
		if(other.gameObject == player)
		{
			Shooting();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.GetComponent<PlayerController> ().PushBack (this.transform);
	}

	public void Shooting()
	{
		if(time > throwTime)
		{
			Instantiate(bullet,gameObject.transform.position,Quaternion.identity);
			this.audio.Play();
			time = 0;
		}
		else
		{
			time += Time.deltaTime;
		}
	}
}
