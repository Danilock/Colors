using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{
public class TimeUI : MonoBehaviour
{
    TimeManager _time;

    TextMeshProUGUI _timeText;

    // Start is called before the first frame update
    void Start()
    {
        _time = FindObjectOfType<TimeManager>();
        _timeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeText();
    }


    /// <summary>
    /// Set text format
    /// </summary>
    void SetTimeText()
    {
        if (_time.Seconds < 9.5f && _time.Seconds > 0f)
        {
            _timeText.text =
                $"{_time.Minutes.ToString()}:0{Convert.ToInt16(_time.Seconds)}"; //Adding a zero when time is behind 10 seconds... Like 0:09 - 0:08
        }
        else if (_time.Seconds > 10f)
        {
            _timeText.text =
                $"{_time.Minutes.ToString()}:{Convert.ToInt16(_time.Seconds)}"; //Set seconds as they are without the zero... Like 0:11 - 0:23
        }
    }
}
}