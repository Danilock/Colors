using System;
using UnityEditor.Build;
using UnityEngine;

namespace Game.Color_System
{
    public class ColorManager : MonoBehaviour
    {
        public enum objColor
        {
            Red, Blue, Yellow
        }

        public objColor objectColor;

        private void Start()
        {
            ChangeColor(objectColor);
        }

        public void ChangeColor(objColor newColor)
        {
            objectColor = newColor;
            gameObject.layer = LayerMask.NameToLayer(objectColor.ToString());
        }

        public void ChangeColor(string newColor)
        {
            switch (newColor)
            {
                case "Red":
                    objectColor = objColor.Red;
                    break;
                case "Yellow":
                    objectColor = objColor.Yellow;
                    break;
                case "Blue":
                    objectColor = objColor.Blue;
                    break;
                
                gameObject.layer = LayerMask.NameToLayer(objectColor.ToString());
            }
        }
    }
}
