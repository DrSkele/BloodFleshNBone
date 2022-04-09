using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDetector : MonoBehaviour
{
    [SerializeField] int side;

    Dice dice;

    private void Awake()
    {
        dice = GetComponentInParent<Dice>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        dice.BottomSide(side);
    }
}
