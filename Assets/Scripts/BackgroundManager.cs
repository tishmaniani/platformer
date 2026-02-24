using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float yOffset = -2.0f;

    public float[] parallaxSpeed;

    private Transform[] layers;
    private float[] startPosX;
    private float[] textureUnitSizeX;

    void Start()
    {
        int childCount = transform.childCount;
        layers = new Transform[childCount];
        startPosX = new float[childCount];
        textureUnitSizeX = new float[childCount];

        for (int i = 0; i < childCount; i++)
        {
    
            layers[i] = transform.GetChild(i);

            startPosX[i] = layers[i].position.x;

            Sprite sprite = layers[i].GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            textureUnitSizeX[i] = (texture.width / sprite.pixelsPerUnit) - 0.05f;

        }

    }

    void LateUpdate()
    {
      transform.position = new Vector3(transform.position.x, _cameraPosition.position.y, transform.position.z); //двигаем по y за камерой

        for (int i = 0; i < layers.Length; i++)
        {
            float movement = _cameraPosition.position.x * parallaxSpeed[i];
            layers[i].localPosition = new Vector3(startPosX[i] + movement, 0, layers[i].localPosition.z);
            Debug.Log(movement);

            float temp = _cameraPosition.position.x * (1 - parallaxSpeed[i]);
            if (temp > startPosX[i] + textureUnitSizeX[i]) startPosX[i] += textureUnitSizeX[i];
            else if (temp < startPosX[i] - textureUnitSizeX[i]) startPosX[i] -= textureUnitSizeX[i];
        }
    }

 }
