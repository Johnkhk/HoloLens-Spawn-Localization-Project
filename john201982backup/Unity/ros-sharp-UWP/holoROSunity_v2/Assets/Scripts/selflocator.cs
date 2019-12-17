using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selflocator : MonoBehaviour
{
    private Vector3 HoloPosition;
    private Quaternion HoloRotation;
    public TextMesh mytext = null;

    private void Start()
    {
        
    }

    //Get camera position = hololens position
    void Update()
    {
        HoloPosition = Camera.main.transform.position;
        HoloRotation = Camera.main.transform.rotation;
        string posstring = HoloPosition.ToString("F2");
        string rotstring = HoloRotation.ToString("F3");

        string stringxyz = $"X,Y,Z = {posstring}";
        string stringrot = "\r\n" + $"Rotation = {rotstring}";


        mytext.text = string.Concat(stringxyz, stringrot);
    }

    //Display position of hololens
    /*
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.Label(new Rect(20, 20, 300, 50), "Position: " + HoloPosition.ToString("F2"), fontSize);
        GUI.Label(new Rect(20, 20, 300, 50), "Rotation: " + HoloRotation.ToString("F3"), fontSize);
    }
    */
}