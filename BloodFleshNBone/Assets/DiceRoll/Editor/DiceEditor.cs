using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dice))]
public class DiceEditor : Editor
{
    Dice dice;

    private void OnSceneGUI()
    {
        foreach (var face in dice.WorldSpaceFaces)
        {
            Handles.DrawLine(dice.Position, face);
        }
    }
    private void OnEnable()
    {
        dice = target as Dice;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
