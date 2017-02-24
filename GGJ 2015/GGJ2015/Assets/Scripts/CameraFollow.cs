using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Vector3 target;
	public GameObject player;
	public float speed = 10f;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		target = player.transform.position;
		this.transform.position = Vector3.Lerp (this.transform.position, new Vector3(target.x,target.y,this.transform.position.z), speed);
	}
}
