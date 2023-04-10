using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Spawning Pellets")]
    [SerializeField] private GameObject pelletPrefab;
    [SerializeField] private GameObject superPelletPrefab;
    [SerializeField] private Tilemap pelletTileMap;
    [SerializeField] private Tilemap superPelletTilemap;
    private List<Vector3> spawnPositions;

    public int currentScore { get; private set; }
   

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

    private void Start()
    {
        spawnPositions = new List<Vector3>();

        SpawnPellets(superPelletTilemap, superPelletPrefab, spawnPositions);
        spawnPositions.Clear();
        SpawnPellets(pelletTileMap, pelletPrefab, spawnPositions); 
    }

    private void Update()
    {
        // if [amount of pellets on screen] == spawnPostions.Lenght / 2
        // Instantiate fruit 
        // max amout of score (not counting ghosts) = 2180
    }

    public void AddPoints(int points)
    {
        currentScore += points;
    }

    private void SpawnPellets(Tilemap tileMap, GameObject spawnObject, List<Vector3> spawnPosList)
    {
        //spawnPosList = new List<Vector3>();

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
                    spawnPosList.Add(place);
                }

            }
        }

        for (int i = 0; i < spawnPosList.Count; i++)
        {
            // spawn prefab at found tiles with half of tile size's offset (1/2 = 0.5)
            Instantiate(spawnObject, new Vector3(spawnPosList[i].x + 0.5f, spawnPosList[i].y + 0.5f, spawnPosList[i].z), Quaternion.identity);
        }

    }
}
