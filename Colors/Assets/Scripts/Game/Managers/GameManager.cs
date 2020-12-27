using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
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
        LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
}
