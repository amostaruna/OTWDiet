using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour
{
    public int scoretoGive;
    private ScoreManager theScoreManager;

    private AudioSource coinSound;

   

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("CoinCollectSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="player")
        {
            theScoreManager.Addscore(scoretoGive);
            gameObject.SetActive(false);
            if(coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
                coinSound.Play();
            
        }
    }
}
