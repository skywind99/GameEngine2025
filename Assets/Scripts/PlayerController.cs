using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 3;
	Animator anim;
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
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

	}
	private void LateUpdate()
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 2.6f), Mathf.Clamp(transform.position.y, -4.6f, 4.6f));
	}
}
