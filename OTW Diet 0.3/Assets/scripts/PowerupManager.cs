using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool saveMode;

    private bool powerUpActive;

    private float powerupLengthCounter;
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float MonsterRate;

    private PlatformDestroyer[] IceManList;
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            powerupLengthCounter -= Time.deltaTime;
            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
            }
            if (saveMode)
            {
                thePlatformGenerator.randomIceManThreshold = 0;
            }

            if(powerupLengthCounter <=0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomIceManThreshold = MonsterRate;
                powerUpActive = false;
            }
        }
    }
    public void ActivatePowerUp(bool points, bool safe, float time)
    {
        doublePoints = points;
        saveMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        MonsterRate = thePlatformGenerator.randomIceManThreshold;

        if(saveMode)
        {
            IceManList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < IceManList.Length; i++)
            {
                if(IceManList[i].gameObject.name.Contains("IceMan"))
                {
                    IceManList[i].gameObject.SetActive(false);
                }
                
            }
        }
        
        powerUpActive = true;
    }
}
