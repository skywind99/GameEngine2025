using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialController : MonoBehaviour
{
	[SerializeField] EnemyGenerator enemyGenerator;
	[SerializeField] TextMeshProUGUI tutorialText;
	private int tutorialStep = 0;
	private float tutorialEndTimer = 4;
	private bool isLeft = false;
	private bool isRight = false;

	private void Awake()
	{
		enemyGenerator.gameObject.SetActive(false);
		tutorialStep = 0;
		tutorialText.text = "Press 'Space' to Shot";
	}
	private void TutorialStep1()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			tutorialText.text = "Press 'Left Arrow and Right Arrow' to move";
			tutorialStep = 1;
		}
	}
	private void TutorialStep2()
	{
		if (isLeft && isRight)
		{
			tutorialStep = 2;

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			isLeft = true;

		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			isRight = true;

		}
	}
	private void TutorialEnd()
	{
		enemyGenerator.gameObject.SetActive(true);
		Destroy(tutorialText);
		Destroy(gameObject);
	}
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (tutorialStep == 0)
		{
			TutorialStep1();
		}
		else if (tutorialStep == 1)
		{
			TutorialStep2();
		}
		else if (tutorialStep == 2)

			{
				if (tutorialEndTimer >= 2)
				{
					tutorialText.text = (tutorialEndTimer - 1).ToString("F0");
				}
				else if (tutorialEndTimer < 2 && tutorialEndTimer > 1)
				{
					tutorialText.text = "==Start==";
				}
				if (tutorialEndTimer <= 1)
				{
					TutorialEnd();
				}
				tutorialEndTimer -= Time.deltaTime;
			}
		}
	}
