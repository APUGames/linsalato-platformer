using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Camera cam;
    public Transform subject;

    Vector2 startPos;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPos;
    Vector2 parallaxFactor;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + travel;
    }
}
