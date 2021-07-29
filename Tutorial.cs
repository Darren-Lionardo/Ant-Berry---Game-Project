using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public int trigger, locked;
    public GameObject text1, text2, text3, text4, text5, text6;
    public GameObject char1, char2;
    public Text textSpace;
    public int textFade = 0;
    public int onTutor;
    RectTransform b;
    void Start()
    {
        onTutor = 1;
        char1.SetActive(true);
        trigger = 1;
        locked = 0;
        b = this.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if(textFade == 0){
            if(textSpace.color.a <= 1f){
                textSpace.color += new Color32(0, 0, 0, 4);
            }
            else{
                textFade = 1;
            }
        }
        if(textFade == 1){
            if(textSpace.color.a >= 0f){
                textSpace.color -= new Color32(0, 0, 0, 4);
            }
            else{
                textFade = 0;
            }
        }
        if(trigger == 1 && b.anchoredPosition.y <= -270){
            b.anchoredPosition = new Vector2(b.anchoredPosition.x, b.anchoredPosition.y + 25);
            b.sizeDelta = new Vector2(b.sizeDelta.x, b.sizeDelta.y + 50);
            locked = 0;
        }
        if(Input.GetKeyUp("space")){
            if(locked == 0){
                trigger += 1;
                locked = 1;
            }
        }
        if(trigger == 2){
            text1.SetActive(false);
            text2.SetActive(true);
            locked = 0;
        }
        if(trigger == 3){
            text2.SetActive(false);
            text3.SetActive(true);
            locked = 0;
        }
        if(trigger == 4){
            text3.SetActive(false);
            text4.SetActive(true);
            locked = 0;
        }
        if(trigger == 5){
            text4.SetActive(false);
            text5.SetActive(true);
            locked = 0;
            char1.SetActive(false);
            char2.SetActive(true);
        }
        if(trigger == 6){
            text5.SetActive(false);
            text6.SetActive(true);
            locked = 0;
        }
        if(trigger >= 7 && b.anchoredPosition.y >= -800){
            b.anchoredPosition = new Vector2(b.anchoredPosition.x, b.anchoredPosition.y - 50);
            b.sizeDelta = new Vector2(b.sizeDelta.x, b.sizeDelta.y - 100);
            locked = 0;
            onTutor = 0;
        }
        if(trigger >= 7 && b.anchoredPosition.y <= -800){
            char2.SetActive(false);
        }
    }
}
