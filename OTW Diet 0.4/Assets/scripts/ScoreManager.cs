using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text coinText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;
    public int coinAmount;
    private pickupPoints thePickupPoints;

    public Double_Score_Powerup doblescore;
    public bool shouldAdd;
    private int newAmount=0;
   
    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        shouldAdd = true;
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if(scoreCount>highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        coinText.text = "Healthy Food: " + coinAmount;
        if (doblescore.yesDoble==true)
            {
              coinAmount=coinAmount - doblescore.coindecrease;
              doblescore.yesDoble = false;
            }
        coinText.text = "Healthy Food: " + coinAmount;
    }
    public void Addscore(int pointToAdd)
    {
        coinAmount++;
        
        if (shouldDouble)
        {
            pointToAdd = pointToAdd * 2;
        }
        scoreCount += pointToAdd;
    }
}
