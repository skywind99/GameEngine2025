using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameDirector : MonoBehaviour
{
	[SerializeField]
	GameObject hpGauge;
	GameObject Score;
	int tempScore = 0;
	// Start is called before the first frame update
	void Start()
	{
		Score = GameObject.Find("Score");
		hpGauge = GameObject.Find("HpGauge");
	}

	// Update is called once per frame
	void Update()
	{

	}
	public void DecreaseHP()
	{
		hpGauge.GetComponent<Slider>().value -= 0.1f;
	}
	public void addScore()
	{
		tempScore += 100;
		Score.GetComponent<TextMeshProUGUI>().SetText("Score : " + tempScore);
	}
}

