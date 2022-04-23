using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody diceBody;
    MeshFilter diceMesh;

    Vector3[] faces;

    Coroutine diceRoll;

    public delegate void DiceEvent(int side);
    public event DiceEvent OnDiceSettled;

    private void Awake()
    {
        diceBody = GetComponent<Rigidbody>();
        diceMesh = GetComponent<MeshFilter>();
        diceBody.useGravity = false;
        faces = GetDiceFaces(diceMesh);
    }
    public virtual Vector3 GetSide(Vector3 upSide)
    {
        float diff = -1;
        Vector3 faceUp = Vector3.zero;
        foreach (var face in faces)
        {
            var dot = Vector3.Dot(face, upSide);
            if (dot > diff)
            {
                diff = dot;
                faceUp = face;
            }
        }
        return faceUp;
    }
    private Vector3[] GetDiceFaces(MeshFilter meshFilter)
    {
        var faces = new List<Vector3>();
        foreach (var norm in meshFilter.mesh.normals)
        {
            if (!faces.Contains(norm))
                faces.Add(norm);
        }
        return faces.ToArray();
    }
}
