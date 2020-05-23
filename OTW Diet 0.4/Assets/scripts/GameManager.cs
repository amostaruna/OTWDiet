using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;
    public GameObject theDoubleScoreButton;
    public Double_Score_Powerup doublePowerup;

    public GameObject FirstPlatform;


    // Start is called before the first frame update
    void Start()
    {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
        if (theScoreManager.coinAmount < 10)
        {
            theDoubleScoreButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (theScoreManager.coinAmount >= 10)
        {
            theDoubleScoreButton.SetActive(true);
        }
        if (theScoreManager.coinAmount < 10)
        {
            theDoubleScoreButton.SetActive(false);
        }
    }
    public void restartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        //StartCoroutine("RestartGameCo"); 

        theDeathScreen.gameObject.SetActive(true);
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        theScoreManager.coinAmount = 0;
        FirstPlatform.SetActive(true);

        
    }
    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i=0; i< platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
