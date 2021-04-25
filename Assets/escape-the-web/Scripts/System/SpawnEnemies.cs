using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public int enemySpawnProb = 1;
    public GameObject ad;
    public Sprite[] adGraphics;
    public GameObject[] enemies;

    public GameObject platformsParent;
    public GameObject enemiesParent;
    public GameObject adsParent;

    void Start()
    {
        // InvokeRepeating("SpawnEnemyAdPair", 0, 1);
    }

    public void SpawnEnemyAdPair()
    {
        if (Random.Range(0, enemySpawnProb) == 0)
        {
            GameObject e = Instantiate(ChooseEnemy());
            e.transform.SetParent(enemiesParent.transform);

            GameObject a = Instantiate(ad);
            bool fromLeft = Random.Range(0, 2) == 0;
            a.transform.position = new Vector3(10 * (fromLeft ? -1 : 1), -6, a.transform.position.z);
            float thrust = Random.Range(0, 50) / 10;
            a.GetComponent<Rigidbody2D>().AddForce(thrust * (fromLeft ? Vector3.right : Vector3.left), ForceMode2D.Impulse);
            a.GetComponent<SpriteRenderer>().sprite = ChooseAdGraphic();
            a.transform.SetParent(adsParent.transform);

            if (e.tag == "WalkingGlitch")
            {
                e.GetComponent<HorizontalMovement>().platform = platformsParent.transform.GetChild(platformsParent.transform.childCount - 1).gameObject;//ChoosePlatform();
            }
            else if (e.tag == "TeleportingGlitch")
            {
                e.GetComponent<RandomTeleport>().platformsParent = platformsParent;
            }
            else
            {
                Debug.Log("Invalid enemy tag");
                Destroy(e);
                Destroy(a);
            }
        }
    }

    GameObject ChooseEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }

    Sprite ChooseAdGraphic()
    {
        return adGraphics[Random.Range(0, adGraphics.Length)];
    }

    GameObject ChoosePlatform()
    {
        return platformsParent.transform.GetChild(Random.Range(0, platformsParent.transform.childCount)).gameObject;
    }
}
