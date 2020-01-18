using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagemove : MonoBehaviour
{
    [SerializeField] float speed = -0.05f;
    [SerializeField] float waitTime = 2f;
    bool m_xPlus = true;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(speed, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laststage")
        {
            Debug.Log("当たってる");
        }    
    }
} 
