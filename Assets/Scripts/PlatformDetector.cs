using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject iPhoneCamParent = GameObject.FindWithTag("AppleCameraParent");
        GameObject AndroidCamParent = GameObject.FindWithTag("AndroidCameraParent");

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            AndroidCamParent.SetActive(false);
            iPhoneCamParent.SetActive(true);
        }   
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidCamParent.SetActive(true);
            iPhoneCamParent.SetActive(false);
        }
        else
        {
            Debug.Log("Platform not currently supported. Defaulting to iOS");
            AndroidCamParent.SetActive(false);
            iPhoneCamParent.SetActive(true);
        }
    }
}
