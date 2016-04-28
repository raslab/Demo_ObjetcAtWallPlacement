﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class App
{
    public GameObject SelectedObject;
    public GameObject SelectedPrefab;

    private static App _instance;
    private ScenesManager _scenesManager;

    public static App Instance
    {
        get { return _instance ?? (_instance = new App()); }
    }

    public ScenesManager ScenesManager
    {
        get { return _scenesManager ?? (_scenesManager = new ScenesManager()); }
    }

    private App()
    {
    }
}

public class ScenesManager
{
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop",LoadSceneMode.Additive);
    }

    public void CloseShop()
    {
        SceneManager.UnloadScene("Shop");
        var wall = GameObject.FindObjectOfType<WallController>();
        wall.SpawnObject();
    }

    public void SetControlsState(bool isCameraMoving)
    {
        var wall = GameObject.FindObjectOfType<WallController>();
        wall.RotateCamera = isCameraMoving;
    }

    public void SetMagnetEnable(bool isMagnetEnable)
    {
        var wall = GameObject.FindObjectOfType<WallController>();
        wall.IsMagnetEnabled = isMagnetEnable;
    }
}
