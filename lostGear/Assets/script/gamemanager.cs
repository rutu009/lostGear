﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    //　メインカメラ
    [SerializeField]
    private GameObject mainCamera;
    //　切り替える他のカメラ
    [SerializeField]
    private GameObject otherCamera;

    // Update is called once per frame
    void Update()
    {
        //　1キーを押したらカメラの切り替えをする
        if (Input.GetKeyDown("1"))
        {
            otherCamera.SetActive(true);
        }
    }
}