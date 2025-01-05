using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLogic : MonoBehaviour
{

    public List<float> Coefs = new List<float>();
    public GameObject finishPanel;
    private float currentScore;
    private float maxScore;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MaxScoreText;

    public Material GoodMaterial;
    public Material BadMaterial;

    private void Start()
    {
        float randomValue = (float)Math.Round(UnityEngine.Random.Range(0f, 5f),2);
        gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"x{randomValue}";
        if (randomValue >= 1)
        {
            gameObject.GetComponent<MeshRenderer>().material = GoodMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = BadMaterial;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        maxScore = PlayerPrefs.GetFloat("MaxScore");
        if (other.CompareTag("Knife"))
        {   
            other.gameObject.GetComponent<KnifeLogic>().MultiplyeScore(Coefs[int.Parse(gameObject.tag) - 1]);
            currentScore = other.gameObject.GetComponent<KnifeLogic>().GetScore();
            if (currentScore > maxScore)
            {
                maxScore = currentScore;
                PlayerPrefs.SetFloat("MaxScore", maxScore);
            }
            finishPanel.SetActive(true);
            Time.timeScale = 0;
            ScoreText.text = $"Score:{currentScore}";
            MaxScoreText.text = $"Max score:{maxScore}";

        }
    }
}
