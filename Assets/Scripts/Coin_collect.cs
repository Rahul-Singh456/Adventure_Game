using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_collect : MonoBehaviour
{
    private Hero_Movement hero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // hero.Scoring();

        Destroy(gameObject);
    }

}