using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField]
	private GameObject gameDirector;
	[SerializeField]
	private GameObject explosionPrefab;
	// Start is called before the first frame update
	void Start()
	{
		gameDirector = GameObject.Find("GameDirector");
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(0, -3 * Time.deltaTime, 0);

		if (transform.position.y < -7.0f)
		{
			Destroy(gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") || collision.CompareTag("Bullet"))
		{

			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			gameDirector.GetComponent<GameDirector>().addScore();
			Destroy(gameObject);
		}
	}
}
