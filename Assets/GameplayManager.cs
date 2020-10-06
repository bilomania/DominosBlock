using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public List<GameObject> boneYard;
    List<GameObject> pool;

    public List<GameObject> playerHand;
    public List<GameObject> enemyHand;

    public GameObject playerHandObj;
    public GameObject enemyHandObj;

    public GameObject playGround;

    public List<GameObject> placedDominos;

    public int currentTurn;
    public int totalDominoesPlaced;

    public bool playerPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        pool = boneYard;

        // foreach(GameObject obj in boneYard)
        // {
        //     GameObject dominoInstance = Instantiate(obj);
        //     dominoInstance.transform.SetParent(playGround.transform);
        // }
        GameInit();

        totalDominoesPlaced = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameInit()
    {
        currentTurn = 0;
        playerPlayed = true;

        for(int i = 0 ;i < 7;i++)
        {
            GameObject randomDomino = pool[Random.Range(0,pool.Count-1)];
            playerHand.Add(randomDomino);
            pool.Remove(randomDomino);
            GameObject randomDominoInstance = Instantiate(randomDomino);
            randomDominoInstance.transform.SetParent(playerHandObj.transform);
        }

        for(int i = 0 ;i < 7;i++)
        {
            GameObject randomDomino = pool[Random.Range(0,pool.Count-1)];
            enemyHand.Add(randomDomino);
            pool.Remove(randomDomino);
            GameObject randomDominoInstance = Instantiate(randomDomino);
            randomDominoInstance.transform.SetParent(enemyHandObj.transform);
        }
    }

    public void Turn()
    {
    //    foreach(GameObject obj in enemyHand)
    //    {
    //        if((obj.GetComponent<DominoObj>().topNum || obj.GetComponent<DominoObj>().bottomNum) == )
    //        {

    //        }
    //    }
    }

    public void GameFinish()
    {

    }
}
