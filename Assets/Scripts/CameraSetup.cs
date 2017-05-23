﻿using UnityEngine;

public class CameraSetup : MonoBehaviour {

    public float screenTop;
    public float screenBottom;
	void Start () {
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = -screenTop;
	}
	
    public float CameraTop()
    {
        return screenTop;
    }

    public float CameraBottom()
    {
        return screenBottom;
    }
}
