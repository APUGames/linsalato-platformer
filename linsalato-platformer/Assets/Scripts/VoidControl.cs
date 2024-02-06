using LDtkUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidControl : MonoBehaviour
{
    public GameObject voidObject;

    // Start is called before the first frame update
    void Start()
    {
        Scene whatLevel = SceneManager.GetActiveScene();
        Debug.Log("active scene is " + whatLevel.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
