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

    void Start()
    {
        pool = boneYard;
        GameInit();
    }


    public void GameInit()
    {
        currentTurn = 0;
        playerPlayed = true;

        for(int i = 0 ;i < 7;i++) //draw 7 dominos from boneyard for player
        {
            GameObject randomDomino = pool[Random.Range(0,pool.Count-1)];
            playerHand.Add(randomDomino);
            pool.Remove(randomDomino);
            GameObject randomDominoInstance = Instantiate(randomDomino);
            randomDominoInstance.transform.SetParent(playerHandObj.transform);
        }

        for(int i = 0 ;i < 7;i++) //draw 7 dominos from boneyard for enemy
        {
            GameObject randomDomino = pool[Random.Range(0,pool.Count-1)];
            enemyHand.Add(randomDomino);
            pool.Remove(randomDomino);
            GameObject randomDominoInstance = Instantiate(randomDomino);
            randomDominoInstance.transform.SetParent(enemyHandObj.transform);
        }
    }

    public void Turn() //attempt to create the enemy's turn
    {

    }

    public void GameFinish()
    {

    }
}
