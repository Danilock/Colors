using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Level_Complete_System;

namespace Game.Sound
{
    public class LevelMusic : MonoBehaviour
    {
        Animator _LevelMusicAnimator;
        // Start is called before the first frame update
        void Start()
        {
            _LevelMusicAnimator = GetComponent<Animator>();
        }


        private void OnEnable()
        {
            DoorsManager.OnLevelStart += ShowSound;
            DoorsManager.OnLevelComplete += HideSound;
        }

        private void OnDisable()
        {
            DoorsManager.OnLevelStart -= ShowSound;
            DoorsManager.OnLevelComplete -= HideSound;
        }

        void ShowSound() => _LevelMusicAnimator.Play("LevelMusicIn");
        void HideSound() => _LevelMusicAnimator.Play("LevelMusicOut");
    }
}