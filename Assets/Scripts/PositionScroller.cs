using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float scrollRange = 9.9f;
	[SerializeField]
	private float speed = 3.0f;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(0, -1 * speed * Time.deltaTime, 0);
		if (transform.position.y <= -scrollRange)
		{
			transform.position = target.position + Vector3.up * 9.9f;
		}
	}
}
