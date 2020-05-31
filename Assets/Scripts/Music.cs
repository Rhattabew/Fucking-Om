using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public GameObject music;


    void Start()
    {
        DontDestroyOnLoad(music);        
    }

}
