using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    [SerializeField] float _minutes;

    public float Minutes
    {
        get { return _minutes; }
        private set { _minutes = value; }
    }

    [SerializeField] float _seconds;

    public float Seconds
    {
        get { return _seconds; }
        private set { _seconds = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.InGame)
        {
            Timer();
        }
    }

    void Timer()
    {
        Seconds -= 1 * Time.deltaTime;

        if (Seconds <= 0)
        {
            if (Minutes > 0)
            {
                Minutes -= 1;
                Seconds = 60;
            }
            else
            {
                GameManager.Instance.RestartLevel();
            }
        }
    }
}
