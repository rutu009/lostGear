using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

    GameObject door;
    Dorebreak script;
    [SerializeField] float destroyTime = 0.1f;
    //　メインカメラ
    [SerializeField]
    private GameObject mainCamera;
    //　切り替える他のカメラ
    [SerializeField]
    private GameObject otherCamera;

    // Use this for initialization
    void Start()
    {
        door = GameObject.Find("Door1");
        script = door.GetComponent<Dorebreak>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            otherCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
        Debug.Log("open");
        script.Onflag();
        Destroy(this.gameObject, destroyTime);
    }
}
