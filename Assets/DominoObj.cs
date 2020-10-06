using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoObj : MonoBehaviour
{
    public Sprite mainImage;

    public int topNum = 0;
    public int bottomNum = 0;

    public GameObject snapTop;
    public GameObject snapBottom;
    public GameObject snapLeft;
    public GameObject snapRight;

    GameplayManager gameplay;

    float imageWidth;
    float imageHeight;

    // Start is called before the first frame update
    void Start()
    {
        gameplay = FindObjectOfType<GameplayManager>();
        imageWidth = GetComponent<RectTransform>().rect.width;
        imageHeight = GetComponent<RectTransform>().rect.height;
        //print("name : " + gameObject.name);
        //mainImage = Resources.Load<Sprite>("dominos2D/"+ gameObject.name.Split(char.Parse("_"))[1].Split(char.Parse("("))[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTap()
    {
        RectTransform playGroundRect = gameplay.playGround.GetComponent<RectTransform>();
        transform.SetParent(playGroundRect.transform, false);

        if(gameplay.currentTurn <= 0)
        {
            transform.localPosition = new Vector2(0,0);
            transform.localRotation = Quaternion.Euler(0,0,90);
        }
        else
        {
            foreach(GameObject obj in gameplay.placedDominos)
            {
                DominoObj dominoScript = obj.GetComponent<DominoObj>();
                if(dominoScript.topNum == dominoScript.bottomNum)
                {
                    if(topNum == dominoScript.topNum && dominoScript.snapLeft.activeInHierarchy)
                    {
                        print("6");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        //transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapLeft.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if(topNum  == dominoScript.topNum && dominoScript.snapRight.activeInHierarchy)
                    {
                        print("7");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        //transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapRight.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if(bottomNum  == dominoScript.topNum && dominoScript.snapLeft.activeInHierarchy)
                    {
                        print("8");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        //transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapLeft.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                    else if(bottomNum  == dominoScript.topNum && dominoScript.snapRight.activeInHierarchy)
                    {
                        print("9");
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        //transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapRight.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                }
                else
                {
                    if((topNum == dominoScript.topNum) && dominoScript.snapTop.activeInHierarchy)
                    {
                        print("1");
                        //transform.SetParent(dominoScript.transform, false);
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapTop.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if((topNum == dominoScript.bottomNum) && dominoScript.snapBottom.activeInHierarchy)
                    {   
                        print("2");
                        //transform.SetParent(dominoScript.transform, false);
                        transform.localPosition = new Vector2(dominoScript.snapBottom.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,90);
                        dominoScript.snapBottom.SetActive(false);
                        snapTop.SetActive(false);
                        return;
                    }
                    else if((bottomNum == dominoScript.topNum) && dominoScript.snapTop.activeInHierarchy)
                    {
                        print("3");
                        //transform.SetParent(dominoScript.transform, false);
                        transform.localPosition = new Vector2(dominoScript.snapTop.transform.localPosition.x - imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,180);
                        dominoScript.snapTop.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                    else if((bottomNum == dominoScript.bottomNum) && dominoScript.snapBottom.activeInHierarchy)
                    {
                        print("4");
                        //transform.SetParent(dominoScript.transform, false);
                        transform.localPosition = new Vector2(dominoScript.snapBottom.transform.localPosition.x + imageHeight,dominoScript.transform.localPosition.y);
                        transform.localRotation = Quaternion.Euler(0,0,-90);
                        dominoScript.snapBottom.SetActive(false);
                        snapBottom.SetActive(false);
                        return;
                    }
                    else
                    {
                        print("5");
                        //pass turn
                    }
                }
            }
        }

        gameplay.currentTurn ++;
        gameplay.placedDominos.Add(gameObject);
        if(gameplay.playerPlayed)
        {
            gameplay.playerPlayed = false;
            gameplay.Turn();
        }
    }
    
}
