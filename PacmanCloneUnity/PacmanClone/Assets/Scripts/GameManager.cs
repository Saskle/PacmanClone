using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentScore;


    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        // spawn pellets
    }

    public void AddPoints(int points)
    {
        currentScore += points;
    }
}
