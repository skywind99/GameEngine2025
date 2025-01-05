using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneController : MonoBehaviour
{
  TextMeshProUGUI textScore;
  // Start is called before the first frame update
  void Start()
  {
    textScore = GetComponent<TextMeshProUGUI>();
    int score = PlayerPrefs.GetInt("Score");
    textScore.text = "Score : " + score;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      SceneManager.LoadScene("IntroScene");
    }
  }
}
