using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using JetBrains.Annotations;


public class CardDeckManager : MonoBehaviour
{

    public GameObject Board;
    public GameObject YellowCard;
    public GameObject RedCard;
    public GameObject BlueCard;
    public GameObject GreenCard;
    List<GameObject> Cards;
    List<Vector3> CardSpawnedPositions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(Board, Vector3.zero, Quaternion.identity);
        CardSetup();
        SpawnSetUp();
    }

    void CardSetup()
    {

        Cards[0] = YellowCard;
        Cards[1] = RedCard;
        Cards[2] = BlueCard;
        Cards[3] = GreenCard;
        CardSpawnedPositions[0] = new Vector3(-4,1,0);
        CardSpawnedPositions[1] = new Vector3(-1,1,0);
        CardSpawnedPositions[2] = new Vector3(1, 1, 0);
        CardSpawnedPositions[3] = new Vector3(4, 1, 0);
        CardSpawnedPositions[4] = new Vector3(-4, -1, 0);
        CardSpawnedPositions[5] = new Vector3(-1, -1, 0);
        CardSpawnedPositions[6] = new Vector3(1, -1, 0);
        CardSpawnedPositions[7] = new Vector3(4, -1, 0);
    }

    void SpawnSetUp()
    { 

        for (int i = 0; i < 4; i++)
        {
            int RandomPos1 = Random.Range(0, 8);
            Instantiate(Cards[0], CardSpawnedPositions[RandomPos1], Quaternion.identity);
            int RandomPos2 = Random.Range(0, 8);
            Instantiate(Cards[0], CardSpawnedPositions[RandomPos2], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
