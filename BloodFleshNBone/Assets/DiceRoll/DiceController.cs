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
            dice.OnDiceSettled += ReadEye;
        }
    }

    public void ReadEye(int side)
    {
        Debug.Log(side);
    }
    [ContextMenu("Roll")]
    public void RollDice()
    {
        foreach (var dice in dices)
        {
            dice.Roll();
        }
    }
}
