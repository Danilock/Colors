using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditorExampleWindow : EditorWindow
{
    int textFieldValue;

    Rect windowRect = new Rect (100 + 100, 100, 100, 100);
        Rect windowRect2 = new Rect (100, 100, 100, 100);
    
    
        [MenuItem ("My Tools/Graph Editor Window")]
        static void Init () {
            EditorWindow.GetWindow (typeof (NodeEditorExampleWindow));
        }
    
        private void OnGUI()
        {
            Handles.BeginGUI();
            Handles.DrawBezier(windowRect.center, windowRect2.center, new Vector2(windowRect.xMax + 50f,windowRect.center.y), new Vector2(windowRect2.xMin - 50f,windowRect2.center.y),Color.red,null,5f);
            Handles.EndGUI();
    
            BeginWindows();
            windowRect = GUI.Window (0, windowRect, WindowFunction, "Box1");
            windowRect2 = GUI.Window (1, windowRect2, WindowFunction, "Box2");
    
            EndWindows();
    
        }
        void WindowFunction (int windowID) 
        {
            GUI.DragWindow();

            if (GUILayout.Button("Plop"))
            {
                Debug.Log("flip");
            }
        }
}
