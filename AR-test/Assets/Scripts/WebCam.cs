using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour
{
    void Awake()
    {
        WebCamTexture web = new WebCamTexture(1280, 720, 60);
        GetComponent<MeshRenderer>().material.mainTexture = web;
        web.Play();
    }

}
