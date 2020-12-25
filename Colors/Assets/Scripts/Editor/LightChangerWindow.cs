using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightChangerWindow : EditorWindow
{
    private float lightIntensity;
    
    [MenuItem("MyTools/Light Modifier")]
    static void Init()
    {
        LightChangerWindow window = (LightChangerWindow) EditorWindow.GetWindow(typeof(LightChangerWindow));

        window.Show();
    }

    private void OnGUI()
    {
        Light2D[] sceneLights = FindObjectsOfType<Light2D>();

        EditorGUILayout.LabelField(sceneLights[0].gameObject.name);
        lightIntensity = EditorGUILayout.FloatField("Light Intensity", lightIntensity);
        sceneLights[0].intensity = lightIntensity;
    }
}
