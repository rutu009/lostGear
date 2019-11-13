using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nenryou : MonoBehaviour
{
    [SerializeField] float maxHp = 200f;
    [SerializeField] Slider hpSlider;
    [SerializeField] float decreaseMove = 0.1f;
    [SerializeField] float decreaseJump = 0.5f;
    [SerializeField] float tagNenryou = 10f;
    float nowHp;

    // Use this for initialization
    void Start()
    {

        //hpSlider = GetComponent<Slider>(); //古の記憶（いじるな）

        nowHp = maxHp;

        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;

        //スライダーの現在値の設定
        hpSlider.value = nowHp;
    }

    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            hpSlider.value -= decreaseMove;
            Debug.Log(hpSlider.value);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hpSlider.value -= decreaseJump;
            Debug.Log(hpSlider.value);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float tagNenryouMax = hpSlider.maxValue - hpSlider.value;
        if (collision.gameObject.tag == "nenryouMax")
        {
            hpSlider.value += tagNenryouMax;
        }
        if (collision.gameObject.tag == "nenryou")
        {
            hpSlider.value += 10;
        }
    }

    // Update is called once per frame
}
