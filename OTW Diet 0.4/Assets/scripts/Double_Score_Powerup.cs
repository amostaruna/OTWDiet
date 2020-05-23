using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Score_Powerup : MonoBehaviour
{
    public bool doublePoints;
    public bool saveMode;
    public float powerUpLength;
    private PowerupManager thePowerupManager;
    public ScoreManager theScoreManager;
    public int coindecrease;
    public bool yesDoble;

    // Start is called before the first frame update
    void Start()
    {
        thePowerupManager = FindObjectOfType<PowerupManager>();
        yesDoble = false;
    }
    public void doble()
    {
        yesDoble = true;
        thePowerupManager.ActivatePowerUp(doublePoints, saveMode, powerUpLength);
        coindecrease = 10;
        print("coindecrease 10");
    }
}
