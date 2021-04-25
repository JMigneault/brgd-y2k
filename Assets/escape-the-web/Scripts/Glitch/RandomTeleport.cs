using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTeleport : MonoBehaviour
{
    public bool teleportImmediately = false;
    public int teleportCooldown = 3;
    public GameObject outline;
    // public GameObject[] platforms;
    public GameObject platformsParent;

    private GameObject platform;
    private bool outlineTeleported = false;

    void Start()
    {
        platform = platformsParent.transform.GetChild(platformsParent.transform.childCount - 1).gameObject;

        // teleport to intitial position
        Teleport();
        Teleport();

        InvokeRepeating("Teleport", teleportImmediately ? 0.001f : teleportCooldown, teleportCooldown);
    }

    public void Teleport()
    {
        if (!platform)
        {
            platform = getNextPlatform();
        }

        if (outlineTeleported)
        {
            transform.position = outline.transform.position;
            outline.transform.position = transform.position; // not sure why this works...
            outlineTeleported = false;
        }
        else
        {
            outline.transform.position = getNextPos();
            outlineTeleported = true;
            platform = getNextPlatform();
        }
    }

    Vector3 getNextPos()
    {
        return (platform ? platform.transform.position : transform.position)
                + Vector3.up * (platform.GetComponent<Renderer>().bounds.size.y/2)
                + Vector3.up * (gameObject.transform.GetChild(1).GetComponent<Renderer>().bounds.size.y/2);
    }

    GameObject getNextPlatform()
    {
        GameObject[] platforms = getPlatforms();
        if (platforms.Length == 1)
        {
            return platforms[0];
        }

        // make sure we don't just choose the same platform
        GameObject next = platform;
        while (next == platform)
        {
            next = platforms[Random.Range(0, platforms.Length)];
        }
        return next;
    }

    GameObject[] getPlatforms()
    {
        GameObject[] platforms = new GameObject[platformsParent.transform.childCount];
        // for (int i = 0; i < transform.childCount; i++)
        for (int i = 0; i < platformsParent.transform.childCount; i++)
        {
            platforms[i] = platformsParent.transform.GetChild(i).gameObject;
        }
        return platforms;
    }
}
