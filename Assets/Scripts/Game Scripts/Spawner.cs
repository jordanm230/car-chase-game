using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Color dim = new Color(0.6320754f, 0.6320754f, 0.6320754f, 0.6509804f);

    public GameObject concrete, grass, gas;
    public GameObject[] obs, npcs;

    private Vector3 sidewalkStart = new Vector3(-6.65f, 8.85f, 0f);
    private float nextSidewalk = 0f;
    private float nextGas = 10f;
    private float nextItem = 0f;
    private int lastLane;

    void Start()
    {
        lastLane = 2;
    }

    void Update()
    {
        if (!Car.gameOver && !Car.paused)
        {
            nextSidewalk -= Time.deltaTime;
            nextGas -= Time.deltaTime;
            nextItem -= Time.deltaTime;

            if (nextSidewalk <= 0f)
            {
                Sidewalk();
                nextSidewalk = 4f;
            }

            if (nextGas <= 0)
            {
                Gas();
                nextGas = Random.Range(4f, 10f);
            }

            if (nextItem <= 0f)
            {
                int rand = Random.Range(0, 2);

                if (rand == 0)
                {
                    Obstacles();
                    nextItem = 0.75f;
                }
                else if (rand == 1)
                {
                    NPCs();
                    nextItem = 0.75f;
                }
            }
        }
    }

    private void Sidewalk()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            Instantiate(concrete, sidewalkStart, Quaternion.identity);
        }
        else if (rand == 1)
        {
            Instantiate(grass, sidewalkStart, Quaternion.identity);
        }

    }

    private void Gas()
    {
        int lane = Random.Range(0, 4);

        if(lane != lastLane)
        {
            if (lane == 0)
            {
                Vector3 pos = new Vector3(Random.Range(-4.55f, -3.75f), 5.6f, 0f);
                Instantiate(gas, pos, Quaternion.identity);
            }
            else if (lane == 1)
            {
                Vector3 pos = new Vector3(Random.Range(-1.65f, -1.05f), 5.6f, 0f);
                Instantiate(gas, pos, Quaternion.identity);
            }
            else if (lane == 2)
            {
                Vector3 pos = new Vector3(Random.Range(1f, 1.6f), 5.6f, 0f);
                Instantiate(gas, pos, Quaternion.identity);
            }
            else if (lane == 3)
            {
                Vector3 pos = new Vector3(Random.Range(3.65f, 4.45f), 5.6f, 0f);
                Instantiate(gas, pos, Quaternion.identity);
            }
        }
        else
        {
            nextGas = 0f;
        }
    }

    private void Obstacles()
    {
        int lane = Random.Range(0, 4);
        int item = Random.Range(0, 4);

        if (lane != lastLane)
        {
            if (lane == 0)
            {
                Vector3 pos = new Vector3(Random.Range(-4.55f, -3.75f), 5.6f, 0f);
                Instantiate(obs[item], pos, Quaternion.identity);
                lastLane = 0;
            }
            if (lane == 1)
            {
                Vector3 pos = new Vector3(Random.Range(-1.65f, -1.05f), 5.6f, 0f);
                Instantiate(obs[item], pos, Quaternion.identity);
                lastLane = 1;
            }
            if (lane == 2)
            {
                Vector3 pos = new Vector3(Random.Range(1f, 1.6f), 5.6f, 0f);
                Instantiate(obs[item], pos, Quaternion.identity);
                lastLane = 2;
            }
            if (lane == 3)
            {
                Vector3 pos = new Vector3(Random.Range(3.65f, 4.45f), 5.6f, 0f);
                Instantiate(obs[item], pos, Quaternion.identity);
                lastLane = 3;
            }
        }
        else
        {
            nextItem = 0f;
        }

    }

    private void NPCs()
    {
        int lane = Random.Range(0, 4);
        int car = Random.Range(0, 4);
        
        if (lane != lastLane)
        {
            if (lane == 0)
            {
                Vector3 pos = new Vector3(-4f, 6.5f, 0f);
                Instantiate(npcs[car], pos, Quaternion.identity);
                lastLane = 0;
            }
            if (lane == 1)
            {
                Vector3 pos = new Vector3(-1.25f, 6.5f, 0f);
                Instantiate(npcs[car], pos, Quaternion.identity);
                lastLane = 1;
            }
            if (lane == 2)
            {
                Vector3 pos = new Vector3(1.4f, 6.5f, 0f);
                Instantiate(npcs[car], pos, Quaternion.identity);
                lastLane = 2;
            }
            if (lane == 3)
            {
                Vector3 pos = new Vector3(4.15f, 6.5f, 0f);
                Instantiate(npcs[car], pos, Quaternion.identity);
                lastLane = 3;
            }
        }
        else
        {
            nextItem = 0f;
        }

    }

    public static void Road(GameObject road, Vector3 roadStart)
    {
        Instantiate(road, roadStart, Quaternion.identity);
    }
}
