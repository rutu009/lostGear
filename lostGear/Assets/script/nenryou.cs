using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nenryou : MonoBehaviour
{
    [SerializeField] float maxHp = 200f;
    [SerializeField] Slider hpSlider;
    [SerializeField] float decreaseMove = 0.1f;
    [SerializeField] float decreaseJump = 0.5f;
    [SerializeField] float tagNenryou = 10f;
    float nowHp;
    [SerializeField] GameObject maxkaihukupanel;
    [SerializeField] GameObject kaihukuPanel;
    [SerializeField] bool kaihuku = true;
    [SerializeField] bool maxkaihuku = true;
    Rigidbody2D r;
    [SerializeField] float texttime = 3.0f;

    // Use this for initialization
    void Start()
    {
        r = GetComponent<Rigidbody2D>();

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
        if (r.bodyType == RigidbodyType2D.Static & Input.GetKeyDown(KeyCode.Space))
        {
            r.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float tagNenryouMax = hpSlider.maxValue - hpSlider.value;
        if (collision.gameObject.tag == "nenryouMax")
        {
            if (maxkaihuku)
            {
                maxkaihukupanel.SetActive(true);
                maxkaihuku = false;
                r.bodyType = RigidbodyType2D.Static;
                Destroy(maxkaihukupanel,texttime);
            }

            hpSlider.value += tagNenryouMax;
        }
        if (collision.gameObject.tag == "nenryou")
        {
            if (kaihuku)
            {
                kaihukuPanel.SetActive(true);
                kaihuku = false;
                r.bodyType = RigidbodyType2D.Static;
                Destroy(kaihukuPanel, texttime);
            }
            hpSlider.value += 10;
        }

        
    }

    // Update is called once per frame
}
