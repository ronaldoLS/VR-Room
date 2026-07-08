using System.Collections;
using System.IO;
using UnityEngine;

public class Polaroid : MonoBehaviour
{
    public GameObject photoPrefab = null;
    public MeshRenderer screenRenderer = null;
    public Transform spawnLocation = null;

    private Camera renderCamera = null;

    private void Awake()
    {
        renderCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        CreateRenderTexture();
        TurnOff();
    }

    private void CreateRenderTexture()
    {
        RenderTexture newTexture = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32);
        //newTexture.antiAliasing = 4;


        renderCamera.targetTexture = newTexture;
        screenRenderer.material.mainTexture = newTexture;
    }

    public void TakePhoto()
    {
        Photo photo = CreatePhoto();
        StartCoroutine(CapturePhoto(photo));
    }

    private Photo CreatePhoto()
    {
        GameObject photoObject = Instantiate(photoPrefab, spawnLocation.position, spawnLocation.rotation, transform);
        return photoObject.GetComponent<Photo>();
    }

    public void TurnOn()
    {
        renderCamera.enabled = true;
        screenRenderer.material.color = Color.white;
    }

    public void TurnOff()
    {
        renderCamera.enabled = false;
        screenRenderer.material.color = Color.black;
    }

    public void SaveImage(Texture2D photo)
    {
        byte[] bytes = photo.EncodeToPNG();

        File.WriteAllBytes(
            Path.Combine(Application.persistentDataPath, "photo.png"),
            bytes);
    }

    private IEnumerator CapturePhoto(Photo photo)
    {
        yield return new WaitForEndOfFrame();

        RenderTexture rt = renderCamera.targetTexture;

        RenderTexture.active = rt;

        Texture2D tex = new Texture2D(
            rt.width,
            rt.height,
            TextureFormat.RGB24,
            false
        );

        tex.ReadPixels(
            new Rect(0, 0, rt.width, rt.height),
            0,
            0
        );

        tex.Apply();

        RenderTexture.active = null;

        photo.SetImage(tex);
    }
}
