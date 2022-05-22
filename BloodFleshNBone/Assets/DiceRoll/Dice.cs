using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Dice : MonoBehaviour
{
    [SerializeField] Rigidbody diceBody;
    [SerializeField] MeshFilter diceMesh;

    Vector3[] _faces;
    public Vector3[] Faces
    {
        get
        {
            if(_faces.Length == 0)
                _faces = GetDiceFaces(diceMesh);
            return _faces;
        }
    }
    public Vector3[] WorldSpaceFaces => FaceToWorldspace(diceBody, _faces);

    public Vector3 Position => diceBody.position;

    public delegate void DiceEvent(int side);

    private void Awake()
    {
        diceBody.useGravity = false;
    }
    public virtual Vector3 GetSide(Vector3 upSide)
    {
        float diff = -1;
        Vector3 faceUp = Vector3.zero;
        foreach (var face in Faces)
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
            {
                faces.Add(norm);
                Debug.Log(norm);
            }
        }
        return faces.ToArray();
    }
    private Vector3[] FaceToWorldspace(Rigidbody body, Vector3[] faces)
    {
        List<Vector3> worldspaceVectors = new List<Vector3>();
        foreach (var face in faces)
        {
            worldspaceVectors.Add(body.position + body.rotation * face);
        }
        return worldspaceVectors.ToArray();
    }
}
