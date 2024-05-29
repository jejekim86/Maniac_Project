 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    //[SerializeField] UIManager Uimanager;
    //[SerializeField] Datamanager Datamanager;

    [SerializeField] private Text timerText;

    int Level = 0;
    float curTime;
    float maxTime;

    int minute;
    int second;

    private static GameManager instance = null;


    void Awake()
    {
        maxTime = 300f;
        StartCoroutine(StartTimer());

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

    IEnumerator StartTimer()
    {
        curTime = maxTime;

        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            timerText.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if (curTime <= 0)
            {
                Debug.Log("생존 성공"); // 결과 창 출력 코드로 변경
                curTime = 0;
                yield break;
            }
        }
    }
    
}
