    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler CarrotPool;
    public ObjectPooler BrocoliPool;
    public ObjectPooler TomatoPool;

    private ObjectPooler[] Foods;
    private int randomFood;
    public int distanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
     
        GameObject coin1 = CarrotPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        
        GameObject coin2 = BrocoliPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
        coin2.SetActive(true);

        
        GameObject coin3 = TomatoPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

}
