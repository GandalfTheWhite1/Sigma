using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float health;
	
	private float nextFire;

	public float meleeAttackDemage;
	public float time = 0;
	public float coolDown = 2f;
	public float meleeRange = 5f;

	public float pushForce = 10f;
	public float waitAmount = 1f;
	public bool moveAble = true;

	public GameObject audioManager;
	void Start () 
	{
		audioManager = GameObject.Find ("AudioManager");
	}
	
	void Update()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		if (moveAble) 
		{
			float hor =Input.GetAxis ("Horizontal");
			float ver =Input.GetAxis ("Vertical");

			this.transform.position += Vector3.right * hor * speed * Time.deltaTime;
			this.transform.position += Vector3.up * ver * speed * Time.deltaTime;

		}

		time += Time.deltaTime;
		if (Input.GetButton ("Fire1"))
		{
			MeleeAttack();
		}
	}

	public void Damage (float damageAmount)
	{
		this.health -= damageAmount;
		if (this.health <= 0)
			Destroy (this.gameObject);
	}

	public void PushBack (Transform trans)
	{
		moveAble = false;
		this.rigidbody2D.AddForce (-(trans.position - this.transform.position) * pushForce);
		StartCoroutine (waitAfterPush ());
	}

	public void MeleeAttack()
	{
		if (time > coolDown) 
		{
			time =0;
			this.audio.Play();
			Collider2D [] hitColliders = Physics2D.OverlapCircleAll(this.transform.position,meleeRange);
			int i = 0;
			while(i<hitColliders.Length)
			{
				Debug.Log(hitColliders[i].gameObject.name);
				if(hitColliders[i].gameObject.name == "Melee")
				{
					Destroy(hitColliders[i].gameObject.transform.parent.gameObject);
					audioManager.GetComponent<AudioManager>().playSound(audioManager.GetComponent<AudioManager>().homelessDeath);
				}
				i++;
			}
		}
	}

	IEnumerator waitAfterPush()
	{
		yield return new WaitForSeconds (waitAmount);
		this.rigidbody2D.velocity = Vector2.zero;
		moveAble = true;
	}
}
