using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore { get; private set; }


    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // singleton implementation
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
        Debug.Log("Score is " + currentScore);
    }
}
