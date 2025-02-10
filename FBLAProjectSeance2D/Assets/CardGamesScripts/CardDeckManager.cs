using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using System;

public class CardDeckManager : MonoBehaviour
{

    [SerializeField] private GameObject Board;
    [SerializeField] private GameObject YellowCard;
    [SerializeField] private GameObject RedCard;
    [SerializeField] private GameObject BlueCard;
    [SerializeField] private GameObject GreenCard;
    List<GameObject> Cards;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CardSetup();
        SpawnSetUp();
    }

    void CardSetup()
    {

        Cards[0] = YellowCard;
        Cards[1] = RedCard;
        Cards[2] = BlueCard;
        Cards[3] = GreenCard;
    }

    void SpawnSetUp()
    {
        Vector3 origin = Vector3.zero;
        Instantiate(Board, Vector3.zero,Quaternion.identity);

        for (int i = 0; i < 4; i++)
        {
            Instantiate(Cards[0], new Vector3(), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
