using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{
    //　メインカメラ
    [SerializeField]
    private GameObject mainCamera;
    //　切り替える他のカメラ
    [SerializeField]
    private GameObject otherCamera;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            otherCamera.SetActive(false);
            mainCamera.SetActive(true);
        } 
    }
}
