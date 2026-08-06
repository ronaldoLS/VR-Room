using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script creates a trail at the location of a gameobject with a particular width and color.
/// </summary>

public class CreateTrail : MonoBehaviour
{
    public GameObject trailPrefab = null;
    private List<GameObject> prints = new List<GameObject>();

    [SerializeField] private Transform TableSpawnPoint = null;

    private float width = 0.05f;
    private Color color = Color.white;

    private GameObject currentTrail = null;


    public void StartTrail()
    {
        if (!currentTrail)
        {
            currentTrail = Instantiate(trailPrefab, transform.position, transform.rotation, transform);
            ApplySettings(currentTrail);
        }
    }

    private void ApplySettings(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = width;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }
    public void saveTrail()
    {
        TrailRenderer trail = currentTrail.GetComponent<TrailRenderer>();

        Mesh mesh = new Mesh();
        trail.BakeMesh(mesh, true);

        GameObject print = new GameObject("Miniature");

        MeshFilter mf = print.AddComponent<MeshFilter>();
        MeshRenderer mr = print.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
        mr.material = trail.material;

        print.transform.position = TableSpawnPoint.position;
        print.transform.localScale = Vector3.one * 0.2f;
        prints.Add(currentTrail);
    }

    public void Print()
    {
        foreach (var print in prints)
        {
            Instantiate(print);
        }
    }


    public void EndTrail()
    {
        if (currentTrail)
        {
            saveTrail();
            currentTrail.transform.parent = null;
            currentTrail = null;
        }
    }

    public void SetWidth(float value)
    {
        width = value;
    }

    public void SetColor(Color value)
    {
        color = value;
    }
}
