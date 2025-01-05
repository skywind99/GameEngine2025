using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 3;
	Animator anim;
	BulletGenerator bullet;
	SpriteRenderer spriteRenderer;
	private GameObject gameDirector;
	// Start is called before the first frame update
	void Start()
	{
		gameDirector = GameObject.Find("GameDirector");
		bullet = GetComponent<BulletGenerator>();
		anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);

		if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
		{
			anim.SetInteger("Input", (int)h);
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			bullet.startFire();
		}
		else if (Input.GetKeyUp(KeyCode.Space)){
			bullet.stopFire();
		}
	}
	private void LateUpdate()
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 2.6f), Mathf.Clamp(transform.position.y, -4.6f, 4.6f));
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			gameDirector.GetComponent<GameDirector>().DecreaseHP();
			StartCoroutine("HitAnimation");
		}
		
	}
	private IEnumerator HitAnimation()
	{
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		spriteRenderer.color = Color.white;

	}
}
