using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Level_Complete_System;

namespace Game.Sound
{
    public class LevelMusic : MonoBehaviour
    {
        Animator _LevelMusicAnimator;
        DoorsManager _DoorsManager;
        // Start is called before the first frame update
        void Start()
        {
            _LevelMusicAnimator = GetComponent<Animator>();
            _DoorsManager = FindObjectOfType<DoorsManager>();

            _DoorsManager.OnLevelStart += ShowSound;
            _DoorsManager.OnLevelComplete += HideSound;
        }

        private void OnDisable()
        {
            _DoorsManager.OnLevelStart -= ShowSound;
            _DoorsManager.OnLevelComplete -= HideSound;
        }

        void ShowSound() => _LevelMusicAnimator.Play("LevelMusicIn");
        void HideSound() => _LevelMusicAnimator.Play("LevelMusicOut");
    }
}