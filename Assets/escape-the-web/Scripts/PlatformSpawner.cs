using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{

    // TODO
    // add free-fall fail-safe; pause player movement if drops below view
    // constant movement

    public Sprite[] spriteArray;
    public GameObject platformBlockPrefab;
    public int platformsSpawned;
    public GameObject enemySpawner;

    int levelWidth = 3;
    float topLevelYPos = 2.2f;
    float bottomLevelYPos = -3.2f;
    float undergroundLevelYPos = -8.2f;
    float levelHeightDifference = 5.0f;

    double blockPrefabWidth;
    float playerHeight;

    GameObject platformObj;
    GameObject playerObj;
    List<GameObject> tileTopRow;
    List<GameObject> allTiles;

    float levelMoveSpeed = 3.0f;
    // float levelMoveSpeed = 0f;
    float levelSpawnRateModifier = 1.5f;
    // higher spawn rate modifier -> the levels spawn faster
    // actual level spawn rate: levelMoveSpeed / levelSpawnRateModifier

    // Start is called before the first frame update
    void Start()
    {
        platformsSpawned = 0;
        this.platformObj = GameObject.Find("Platform");
        this.playerObj = GameObject.Find("Player");
        this.playerHeight = this.playerObj.GetComponent<Renderer>().bounds.size.y;
        Renderer blockPrefabRenderer = platformBlockPrefab.GetComponent<Renderer>();
        blockPrefabWidth = blockPrefabRenderer.bounds.size.x;
        // levelWidth = (int) (Screen.width / blockPrefabWidth);
        // print("level width: " + levelWidth);

        allTiles = new List<GameObject>();

        generateNewLevel(topLevelYPos);
        generateNewLevel(bottomLevelYPos);

        InvokeRepeating("generateUndergroundLevel", 0f, levelMoveSpeed / levelSpawnRateModifier);

        // this.playerObj.transform.position = allTiles[allTiles.Count - 1].transform.position + Vector3.up*this.playerHeight;

    }

    void Update()
    {
        moveUp();
    }

    void generateUndergroundLevel()
    {
        generateNewLevel(undergroundLevelYPos);
    }

    void moveUp()
    {
        float step = levelMoveSpeed * Time.deltaTime; // calculate distance to move
        foreach (GameObject tile in allTiles)
        {
            if (tile)
                tile.transform.Translate (Vector3.up * Time.deltaTime * levelMoveSpeed);
        }
    }

    void generateNewLevel(float height) {
        // int carveGapStartBlock = Random.Range(0, levelWidth - 1);
        // randomly adjust height between bottom level and underground
        // if ((i == carveGapStartBlock) || (i == carveGapStartBlock + 1))
        // {
        //     continue;
        // }
        // GameObject tile = createTile(i, height);

        float leftMostX = -5f + Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).x;
        float rightMostX = -5f + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;

        int spawnXBlocks = (int) (Random.Range(1, levelWidth - 1));

        float xPos;
        float maxXPos;
        float minXPos;

        minXPos = (float) (leftMostX + blockPrefabWidth / 2);
        maxXPos = (float) (rightMostX - spawnXBlocks * blockPrefabWidth);

        if (spawnXBlocks == 1) {
            int leanTowardsValue = Random.Range(0, 4);
            // print("lean towards: " + leanTowardsValue);
            if (leanTowardsValue == 0)
            {
                // lean towards the left
                minXPos = leftMostX;
                maxXPos = leftMostX + (float) blockPrefabWidth;
            }
            else if (leanTowardsValue == 1)
            {
                // lean towards the right
                minXPos = rightMostX - (float) blockPrefabWidth;
                maxXPos = rightMostX;
            }
            else
            {
                // lean towards the middle
                minXPos = leftMostX + (float) blockPrefabWidth;
                maxXPos = rightMostX - (float) blockPrefabWidth;
            }
        }

        xPos = Random.Range(minXPos, maxXPos);
        // print("camera: " + minXPos + "~" + rightMostX);
        // print("first block spawns at: " + xPos);

        for (int blocksLeft = spawnXBlocks - 1; spawnXBlocks >= 0; spawnXBlocks--) {

            float maxHeight = height + this.levelHeightDifference / 3;
            float randomHeight = Random.Range(height, maxHeight);

            allTiles.Add(createTile(xPos, randomHeight));

            minXPos = xPos + (float) blockPrefabWidth * 1.5f;
            maxXPos = (float) (rightMostX - blocksLeft * blockPrefabWidth);
            xPos = Random.Range(minXPos, maxXPos);
        }
    }

    GameObject createTile(float xPos, float yPos)
    {
        Vector3 tilePosition = new Vector3(xPos, yPos, 0);
        GameObject tile = (GameObject) Instantiate(platformBlockPrefab, tilePosition, Quaternion.identity);

        tile.transform.SetParent(this.platformObj.transform);
        enemySpawner.GetComponent<SpawnEnemies>().SpawnEnemyAdPair();

        // assign random platform sprite
        int randomSpriteIndex = Random.Range(0, spriteArray.Length);
        SpriteRenderer spriteRenderer = platformBlockPrefab.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[randomSpriteIndex];

        return tile;
    }
}
