using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    Volume volume;
    public static bool isGameRunning = true;
    //[SerializeField]
    static GameManager instance;
    Vignette vignette;
    public static List<GameObject> ObjectToFollow= new List<GameObject>();
    float timer = 0f;
    [SerializeField] int gameLostCondition = 2;
    public static int deathCount = 0;
    private void Awake()
    {
        volume = FindObjectOfType<Volume>();
        volume.sharedProfile.TryGet<Vignette>(out vignette);
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
    private void Start()
    {
        vignette.intensity.Override(0f);
    }
    private void Update()
    {
        if (deathCount >= gameLostCondition)
        {
            DoVignette();
            if (isGameRunning)
            {
                GameLost();
            }
        }
    }
    public void GameWon()
    {
        isGameOver = true;
        isGameRunning = false;

    }
    public void GameLost()
    {
        isGameOver = true;
        isGameRunning = false;
    }

    private void DoVignette()
    {
        timer += (Time.deltaTime / 4);
        if (timer >= 1f) { timer = 1f; }
        vignette.intensity.Override(timer);
    }

}
