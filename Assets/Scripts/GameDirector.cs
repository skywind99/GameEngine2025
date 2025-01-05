using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
		if (hpGauge.GetComponent<Slider>().value <= 0)
		{
			SceneManager.LoadScene("EndScene");
			PlayerPrefs.SetInt("Score",tempScore);
		}
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

