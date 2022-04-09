using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody diceBody;

    Coroutine diceRoll;

    int lastSideLanded;
    public int Side { get; private set; }
    public bool IsSettled { get; private set; } = false;

    public delegate void DiceEvent(int side);
    public event DiceEvent OnDiceSettled;

    private void Awake()
    {
        diceBody = GetComponent<Rigidbody>();
        diceBody.useGravity = false;
    }

    public virtual void Roll()
    {
        if (diceRoll != null)
            return;
        diceRoll = StartCoroutine(CO_Roll());
    }
    private IEnumerator CO_Roll()
    {
        IsSettled = false;
        diceBody.useGravity = true;

        while (!IsSettled)
        {
            yield return new WaitForFixedUpdate();

            if (diceBody.velocity == Vector3.zero)
                IsSettled = true;
        }
        Side = lastSideLanded;
        OnDiceSettled.Invoke(Side);
    }
    public virtual void BottomSide(int side)
    {
        this.lastSideLanded = side;
    }
}
