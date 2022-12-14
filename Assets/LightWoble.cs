using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightWoble : MonoBehaviour
{
    Action ChangeLight;
    [SerializeField] float time = 0.1f;
    [SerializeField] Light lightTrail;
    [SerializeField] float minIntensity = 1f;
    [SerializeField] float maxIntensity = 10f;
    float timer;
    bool bigLight = false;
    private void OnEnable()
    {
        ChangeLight += SwitchLight;
    }
    private void OnDisable()
    {
        ChangeLight -= SwitchLight;
    }
    private void Update()    
    {
        timer += Time.deltaTime;
        if(timer > time){
            ChangeLight?.Invoke();
            timer = 0;
        }
    }
    void SwitchLight(){
        bigLight = !bigLight;
        lightTrail.intensity = bigLight ? minIntensity : maxIntensity;
    }
}
