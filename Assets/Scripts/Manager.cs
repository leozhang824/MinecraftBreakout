using TMPro;
using UnityEditor.Timeline;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public static Manager Singleton;

    public static void ScorePoints(int points)
    {
        Singleton.ScorePointsInternal(points);
    }

    public static void LivesLeft(int lives)
    {
        Singleton.LivesLeftInternal(lives);
    }

    public static void OreIncrease(int lives, string type)
    {
        Singleton.OreIncreaseInternal(lives, type);
    }

    public static void End()
    {
        Singleton.EndGame();
    }
    
    public int Score;
    
    public int MaxLives = 10;

    private int currLives;

    public TMP_Text scoreDisplay;
    
    public TMP_Text livesDisplay;

    public AudioClip scoreChange;

    private AudioSource audioSource;

    
    void Start()
    {
        Singleton = this;
        
        audioSource = GetComponent<AudioSource>();
        
        ScorePointsInternal(0, false);
        LivesLeftInternal(MaxLives);
        OreIncreaseInternal(0,"all");
    }

    void Update() {
        if (currLives == 0) {
            EndGame();
        }
    }

    private void ScorePointsInternal(int delta, bool start = true)
    {
        if (delta == 0) {
            Score = 0;
        }
        Score += delta;
        if (start && audioSource != null) {
            audioSource.PlayOneShot(scoreChange);
        }
        scoreDisplay.text = "Score: " + Score;
    }

    private void LivesLeftInternal(int delta)
    {
        if (delta == MaxLives) {
            currLives = MaxLives;
        } else {
            currLives -= delta;
        }
        livesDisplay.text = "Lives: " + currLives;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public TMP_Text stoneDisplay;
    private int Stone;
    public TMP_Text ironDisplay;
    private int Iron;
    public TMP_Text diamondDisplay;
    private int Diamond;

    private int level = 0;
    private void OreIncreaseInternal(int delta, string type)
    {
        if (delta == 0) {
            Stone = 0;
            Iron = 0;
            Diamond = 0;
        } else if (type == "Stone") {
            Stone += delta;
        } else if (type == "Iron") {
            Iron += delta;
        } else if (type == "Diamond") {
            Diamond += delta;
        }
        stoneDisplay.text = "Stone Mined: " + Stone + "/3";
        ironDisplay.text = "Iron Mined: " + Iron + "/3";
        diamondDisplay.text = "Diamond Mined: " + Diamond + "/3";
        
        if (Stone == 3 && level == 0) {
            level++;
            Pickaxe.SpriteUpdate(1);
        } else if (Iron == 3 && level == 1) {
            level++;
            Pickaxe.SpriteUpdate(1);
        } else if (Diamond == 3 && level == 2) {
            level++;
            Pickaxe.SpriteUpdate(1);
        }   
    
    }

}
