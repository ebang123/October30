using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueAudio : MonoBehaviour {

    private static ContinueAudio instance = null;
    public static ContinueAudio Instance
    
    {
        get { return instance; }
    }

    void Awake()
    {

        if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
        DontDestroyOnLoad(transform.gameObject);
    }

   

}
