using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottonopen : MonoBehaviour {
    GameObject door;
    Dorebreak script;
    [SerializeField] float destroyTime = 0.1f;

	// Use this for initialization
	void Start () {
        door = GameObject.Find("Door");
        script = door.GetComponent<Dorebreak>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("open");
        script.Onflag();
        Destroy(this.gameObject,destroyTime);
    }
}
