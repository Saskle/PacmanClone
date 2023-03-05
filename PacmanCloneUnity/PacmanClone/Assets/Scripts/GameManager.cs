using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pelletPrefab;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private List<Vector3> spawnPositions;

    public int currentScore { get; private set; }
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton implementation
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
        SpawnPellets();
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        Debug.Log("Score is " + currentScore);
    }

    private void SpawnPellets()
    {
        spawnPositions = new List<Vector3>();

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++) // scan the tilemap from left to right for tiles
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++) // scan from bottom to top for tiles
            {
                // find local position of current tile on the tilemap and convert this to world coordinates
                Vector3Int localPlace = new Vector3Int(n, p, (int)tileMap.transform.position.y);
                Vector3 place = tileMap.CellToWorld(localPlace);
                
                // if there is a tile at localPlace, add it to the list
                if (tileMap.HasTile(localPlace))
                {
                    spawnPositions.Add(place);
                }

            }
        }

        for (int i = 0; i < spawnPositions.Count; i++)
        {
            // spawn prefab at found tiles with half of tile size's offset (0.35/2 = 0.175)
            Instantiate(pelletPrefab, new Vector3(spawnPositions[i].x + 0.175f, spawnPositions[i].y + 0.175f, spawnPositions[i].z), Quaternion.identity);
        }

    }
}
