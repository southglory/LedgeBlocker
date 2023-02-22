using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Color highRate;
    public Color midRate;
    public Color lowRate;
    public Image fill;

    Slider mySlider;

    void Start()
    {
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        float remain = GameManager.maxTime - GameManager.playTime;
        float rate = remain / GameManager.maxTime;
        mySlider.value = rate;

        if (rate > 0.7f)
        {
            fill.color = highRate;
        }
        else if (rate > 0.3f)
        {
            fill.color = midRate;
        }
        else 
        {
            fill.color = lowRate;
        }
    }
}
