using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRecordUI : MonoBehaviour
{
    Text myText;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
            return;

        myText = GetComponent<Text>();
        myText.text = gameObject.name + string.Format(" {0:F0}", PlayerPrefs.GetFloat("Score"));
    }
}
