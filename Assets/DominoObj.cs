using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoObj : MonoBehaviour
{
    public Sprite mainImage;

    public int topNum = 0;
    public int bottomNum = 0;

    // Snap points to check for available domino slot
    public GameObject snapTop;
    public GameObject snapBottom;      
    public GameObject snapLeft;
    public GameObject snapRight;

    GameplayManager gameplay;

    float imageWidth;
    float imageHeight;

    void Start()
    {
        gameplay = FindObjectOfType<GameplayManager>();
        imageWidth = GetComponent<RectTransform>().rect.width;
        imageHeight = GetComponent<RectTransform>().rect.height;

    }
    // when player/machine taps a domino from their hand
    public void OnTap()
    {
        RectTransform playGroundRect = gameplay.playGround.GetComponent<RectTransform>();
        transform.SetParent(playGroundRect.transform, false);

        //At the start of the match
        if(gameplay.currentTurn <= 0)
        {
            transform.localPosition = new Vector2(0,0);
            transform.localRotation = Quaternion.Euler(0,0,90);
        }
        else // for every other turn
        {
            foreach(GameObject obj in gameplay.placedDominos) //iteration inside the placed dominos
            {
                DominoObj dominoScript = obj.GetComponent<DominoObj>();//fetch the domino script from placed domino
                if(dominoScript.topNum == dominoScript.bottomNum) //when the placed domino has double number
                {
                    if(topNum == dominoScript.topNum && dominoScript.snapLeft.activeInHierarchy)
                    {
                        print("double domino 1");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        dominoScript.snapLeft.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if(topNum  == dominoScript.topNum && dominoScript.snapRight.activeInHierarchy)
                    {
                        print("double domino 2");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        dominoScript.snapRight.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if(bottomNum  == dominoScript.topNum && dominoScript.snapLeft.activeInHierarchy)
                    {
                        print("double domino 3");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        dominoScript.snapLeft.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                    else if(bottomNum  == dominoScript.topNum && dominoScript.snapRight.activeInHierarchy)
                    {
                        print("double domino 4");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        dominoScript.snapRight.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                }
                else //when the placed domino has different numbers
                {
                    if((topNum == dominoScript.topNum) && dominoScript.snapTop.activeInHierarchy)
                    {
                        print("single dominos 1");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapTop.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if((topNum == dominoScript.bottomNum) && dominoScript.snapBottom.activeInHierarchy)
                    {   
                        print("single dominos 2");
                        transform.localPosition = new Vector2(dominoScript.snapBottom.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,90);
                        dominoScript.snapBottom.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if((bottomNum == dominoScript.topNum) && dominoScript.snapTop.activeInHierarchy)
                    {
                        print("single dominos 3");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapTop.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                    else if((bottomNum == dominoScript.bottomNum) && dominoScript.snapBottom.activeInHierarchy)
                    {
                        print("single dominos 4");
                        transform.localPosition = new Vector2(dominoScript.snapBottom.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,-90);
                        dominoScript.snapBottom.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                    else
                    {
                        print("pass");
                    }
                }
            }
        }

        gameplay.currentTurn ++; //increment of turns
        gameplay.placedDominos.Add(gameObject); //add the tapped domino to the placed dominos
        // if(gameplay.playerPlayed) // an attempt for enemy turn
        // {
        //     gameplay.playerPlayed = false;
        //     gameplay.Turn();
        // }

    }
    
}
