using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Controller : MonoBehaviour
{

    public float lives;
    public GameObject playerRef;
    public Texture lifeSpriteRef;


    void Start()
    {
    }

    void OnGUI()
    {

        Rect r = new Rect(0,0,5f,5f);
        GUILayout.BeginArea(r);
        GUILayout.BeginHorizontal();
        GUILayout.Button("Test!");
        for (int i = 0; i < lives; i++)
        {
            GUILayout.Label(lifeSpriteRef);
            GUILayout.Label("Life : " + i);

        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

}
