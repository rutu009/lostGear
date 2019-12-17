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
    [SerializeField] string m_gameover = "gameover";
    [SerializeField] string m_gameclear = "gameclear";
    [SerializeField] float fadespeed = 1.0f;

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
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hpSlider.value -= decreaseJump;
        }
        if (r.bodyType == RigidbodyType2D.Static && Input.GetKeyDown(KeyCode.Q) && !maxkaihuku && maxkaihukupanel)
        {
            r.bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("aa");
            Destroy(maxkaihukupanel);
        }
        if (r.bodyType == RigidbodyType2D.Static && Input.GetKeyDown(KeyCode.Q) && !kaihuku && kaihukuPanel)
        {
            r.bodyType = RigidbodyType2D.Dynamic;
            Destroy(kaihukuPanel);
        }
        if (hpSlider.value <= 0)
        {
            Initiate.Fade(m_gameover, Color.black, fadespeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float tagNenryouMax = hpSlider.maxValue - hpSlider.value;
        if (collision.gameObject.tag == "nenryouMax")
        {
            if (maxkaihuku)
            {
                maxkaihukupanel.SetActive(true);
                maxkaihuku = false;
                r.bodyType = RigidbodyType2D.Static;
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
            }
            hpSlider.value += 10;
        }
        if (collision.gameObject.tag == "gameclear")
        {
            Initiate.Fade(m_gameclear, Color.black, fadespeed);
        }
    }
    // Update is called once per frame
}
