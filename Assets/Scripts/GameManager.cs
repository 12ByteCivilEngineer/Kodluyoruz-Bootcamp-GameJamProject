using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameRunning = true;
    static GameManager instance;
    public static List<GameObject> ObjectToFollow= new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

}
