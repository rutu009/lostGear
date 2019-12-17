using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorebreak : MonoBehaviour {
    public Animator animator;
    bool m_flag = false;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (m_flag)
        {
            animator.SetBool("open",true);
        }
    }
    public void Onflag()
    {
        m_flag = true;
    }
}
