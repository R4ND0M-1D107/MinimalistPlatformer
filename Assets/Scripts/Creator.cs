using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public static float PositionX;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;
    public GameObject k;
    int randNumber;
    private int lastNumber;
    bool platformRequired;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        PositionX = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Instantiate(a, new Vector3(PositionX, 0), Quaternion.identity);
        PositionX += 17.35f;
    }

    // Update is called once per frame
    void Update()
    {
        if((PositionX - player.position.x ) < 50)
        Create();
    }


    

    int GetRandom(int min, int max)
    {
        randNumber = Random.Range(min, max);
        while (randNumber == lastNumber)
            randNumber = Random.Range(min, max);
        lastNumber = randNumber;
        return randNumber;
    }
    void Create()
    {
        GetRandom(1, 12);
        if (randNumber == 1)
        {
            Instantiate(a, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = false;
        }else if (randNumber == 2)
        {
            Instantiate(b, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = false;
        }
        else if (randNumber == 3 && platformRequired == false)
        {
            Instantiate(c, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = true;
        }
        else if (randNumber == 4)
        {
            Instantiate(d, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = false;
        }
        else if (randNumber == 5)
        {
            Instantiate(e, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = false;
        }
        else if (randNumber == 6)
        {
            Instantiate(f, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = false;
        }
        else if (randNumber == 7 && platformRequired == false)
        {
            Instantiate(g, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 34.7f;
            platformRequired = true;
        }
        else if (randNumber == 8 && platformRequired == false)
        {
            Instantiate(h, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 34.7f;
            platformRequired = true;
        }
        else if (randNumber == 9 && platformRequired == false)
        {
            Instantiate(i, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = true;
        }
        else if (randNumber == 10 && platformRequired == false)
        {
            Instantiate(j, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = true;
        }
        else if (randNumber == 11 && platformRequired == false)
        {
            Instantiate(k, new Vector3(PositionX, 0), Quaternion.identity);
            PositionX += 17.35f;
            platformRequired = true;
        }
        else
        {
            Create();
        }
    }
}
