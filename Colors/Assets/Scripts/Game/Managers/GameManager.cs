using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int m_LastLevel;
    [SerializeField] private Animator m_TransitionAnimator;
    public enum GameState
    {
        Paused,
        InGame,
        Loading,
        InMenu,
        PlayerWin,//Level Completed
        PlayerLose
    }

    public GameState currentGameState;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
                print("Manager is Null");

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            InitiateLastLevelPrefVariable();
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    #region Level Management
    public void LoadScene(string sceneName)
    {
        currentGameState = GameState.Loading;
        StartCoroutine(AsyncScene(sceneName));
    }

    private IEnumerator AsyncScene(string sceneToAsync)
    {
        m_TransitionAnimator.SetTrigger("Transition");
        
        yield return  new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneToAsync);
    }

    public void RestartLevel()
    {
        currentGameState = GameState.Loading;
        LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region Data Saving

    void InitiateLastLevelPrefVariable()
    {
        m_LastLevel = PlayerPrefs.HasKey("Last Level") ? PlayerPrefs.GetInt("Last Level") : 0;
        Debug.Log(m_LastLevel);
    }
    public void SaveGame(int level)
    {
        if (level > m_LastLevel)
        {
            PlayerPrefs.SetInt("Last Level", level);
        }
    }
    #endregion
}
