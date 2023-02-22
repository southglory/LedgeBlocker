using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text myText;
    string myName;

    void Start()
    {
        myText = GetComponent<Text>();
        myName = gameObject.name;
    }

    void LateUpdate()
    {
        myText.text = myName + string.Format(" {0:F0}", GameManager.score);
    }
}
