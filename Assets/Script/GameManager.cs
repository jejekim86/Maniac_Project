using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    //[SerializeField] UIManager Uimanager;
    //[SerializeField] Datamanager Datamanager;
    int Level = 0;
    float ingameTime = 0;
    float maxTime = 0;

    private static GameManager instance = null;


    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }
    }


    
}
