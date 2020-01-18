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
    [SerializeField] float enemydamage = 10f;
    [SerializeField] Text timertext;
    bool m_isworking = true;
    float timer;
    public bool damage = false;
    public SpriteRenderer renderer;

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
        if (m_isworking)
        {
            timer += Time.deltaTime;
            Refresh();
        }
        if (damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hpSlider.value -= enemydamage;
            DamageEffect();
        }    
    }

    void OnTriggerEnter2D(Collider2D collision)
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

    void DamageEffect()
    {
        // ダメージフラグON
        damage = true;

        // プレイヤーの位置を後ろに飛ばす
        float s = 100f * Time.deltaTime;
        transform.Translate(Vector3.up * s);

        // プレイヤーのlocalScaleでどちらを向いているのかを判定
        if (transform.localScale.x >= 0)
        {
            transform.Translate(Vector3.left * s);
        }
        else
        {
            transform.Translate(Vector3.right * s);
        }

        // コルーチン開始
        StartCoroutine("WaitForIt");
    }

    IEnumerator WaitForIt()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Refresh()
    {
        timertext.text = timer.ToString("F2");
    }
}
