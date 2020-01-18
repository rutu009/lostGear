using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestage : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "movestage")
        {
            transform.SetParent(collision.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "movestage")
        {
            transform.SetParent(null);
        }
    }
}
