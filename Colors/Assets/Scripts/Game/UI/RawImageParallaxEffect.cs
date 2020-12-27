using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UI;

namespace Game.UI
{
    public class RawImageParallaxEffect : MonoBehaviour
    {
        [SerializeField] private ParallaxType parallaxType;
        [SerializeField] private RawImage[] images;
        [SerializeField] private RawImage image;
        [SerializeField] private Vector2 parallaxSpeed;
        private Rect ActualUVRect;
        private void Update()
        {
            if (parallaxType == ParallaxType.Single)
            {
                ApplyEffectToImage(image);   
            }
            else if(parallaxType == ParallaxType.Multiple)
            {
                foreach (var image in images)
                {
                    ApplyEffectToImage(image);
                }
            }
        }

        void ApplyEffectToImage(RawImage imageToChange)
        {
            ActualUVRect = imageToChange.uvRect;
            ActualUVRect.x += parallaxSpeed.x * Time.deltaTime;
            ActualUVRect.y += parallaxSpeed.y * Time.deltaTime;

            imageToChange.uvRect = ActualUVRect;
        }
        
        [ContextMenu("Add")]
        void FindAllRawImages()
        {
            images = FindObjectsOfType<RawImage>();
        }
    }
}

public enum ParallaxType
{
    Single,
    Multiple
}