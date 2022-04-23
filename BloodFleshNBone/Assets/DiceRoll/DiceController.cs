using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] List<Dice> dices = new List<Dice>();

    private void Start()
    {
        foreach (var dice in dices)
        {
            Debug.Log(dice.GetSide(Vector3.up));
        }
    }
}
