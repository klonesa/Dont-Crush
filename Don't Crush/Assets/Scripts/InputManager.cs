using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UISystems;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    #region Singleton
    private static InputManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public static InputManager GetInstance()
    {
        return _instance;
    }
    #endregion
    

    private void Start()
    {
        Debug.Log("Started");
    }

    private void Update()
    {
            
            // if (Input.GetMouseButton(0) )
            // {
            //     Debug.Log("aklsdjklf");
            //     FillBar.GetInstance().mustMove = true;
            //     FillBar.GetInstance().FillBarPingPong();
            //     Predicter.GetInstance()._lineRenderer.SetPosition(1, Predicter.GetInstance().hit.point);
            // }
            // else
            // {
            //     Debug.Log("");
            // }
            //
            // if (Input.GetMouseButtonUp(0) )
            // {
            //     FillBar.GetInstance().mustMove = false;
            //     Shooter.GetInstance().ThrowBall(Predicter.GetInstance().hit);
            //     StartCoroutine(Shooter.GetInstance().CameraShake(0.5f, 1f));
            // }
            // else
            // {
            //     Debug.Log("");
            // }
        

        
        
        
        
    }
    
    
}
