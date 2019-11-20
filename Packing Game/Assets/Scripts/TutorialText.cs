using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
