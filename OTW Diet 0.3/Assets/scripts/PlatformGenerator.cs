﻿using System.Collections;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoingenerator;

    public float randomCoinThreshold;

    public float randomIceManThreshold;
    public float randomCandyManThreshold;
    public float randomPizzaManThreshold;

    public ObjectPooler PizzaManPool;
    public ObjectPooler IceManPool;
    public ObjectPooler CandyManPool;

    // Use this for initialization
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
       platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCoingenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y +Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            
            //Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            //random coin spawn
            if(Random.Range(0f, 100f)<randomCoinThreshold)
            {
                theCoingenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            //random IceMan spawn
            if (Random.Range(0f, 100f) < randomIceManThreshold)
            {
                GameObject newMonster = IceManPool.GetPooledObject();

                float IceManXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 monsterPosition = new Vector3(0f, 0.5f, 0f);
                newMonster.transform.position = transform.position +monsterPosition;
                newMonster.transform.rotation = transform.rotation;
                newMonster.SetActive(true);
            }
            //random CandyMan Spawn
            if (Random.Range(0f, 100f) < randomCandyManThreshold)
            {
                GameObject newMonster = CandyManPool.GetPooledObject();

                float CandyManXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 monsterPosition = new Vector3(0f, 0.5f, 0f);
                newMonster.transform.position = transform.position + monsterPosition;
                newMonster.transform.rotation = transform.rotation;
                newMonster.SetActive(true);
            }
            //random PizzaMan Spawn
            if (Random.Range(0f, 100f) < randomPizzaManThreshold)
            {
                GameObject newMonster = PizzaManPool.GetPooledObject();

                float PizzaManXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 monsterPosition = new Vector3(0f, 0.5f, 0f);
                newMonster.transform.position = transform.position + monsterPosition;
                newMonster.transform.rotation = transform.rotation;
                newMonster.SetActive(true);
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) , transform.position.y, transform.position.z);

        }

    }
}
