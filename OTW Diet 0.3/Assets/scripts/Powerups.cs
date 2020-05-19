using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool doublePoints;
    public bool saveMode;

    public float powerUpLength;
    private PowerupManager thePowerupManager;
    // Start is called before the first frame update
    void Start()
    {
        thePowerupManager = FindObjectOfType<PowerupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            thePowerupManager.ActivatePowerUp(doublePoints, saveMode, powerUpLength);

        }
        gameObject.SetActive(false);
    }

}
