using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IScrollHandler
{
    public string apiKey;

    public float lat = -33.8566f;
    public float lon = 151.2150f;

    [Range(1, 20)]
    public int zoom = 12;

    public enum resolution { low = 1, high = 2 }
    public resolution mapResolution = resolution.low;

    public enum type { roadmap, satellite, hybrid, terrain }
    public type mapType = type.roadmap;

    float latLast, lonLast;
    int zoomLast;
    resolution mapResolutionLast;
    type mapTypeLast;
    string apiKeyLast;

    Rect rect;
    int mapWidth;
    int mapHeight;

    bool updateMap = true;
    bool dragging;
    Vector2 lastMouse;

    public float panSpeed = 0.0008f;
    public float zoomSpeed = 1f;

    void Start()
    {
        rect = GetComponent<RawImage>().rectTransform.rect;
        mapWidth = (int)rect.width;
        mapHeight = (int)rect.height;

        latLast = lat;
        lonLast = lon;
        zoomLast = zoom;
        mapResolutionLast = mapResolution;
        mapTypeLast = mapType;
        apiKeyLast = apiKey;

        StartCoroutine(GetGoogleMap());
    }

    void Update()
    {
        if (updateMap &&
            (lat != latLast || lon != lonLast || zoom != zoomLast ||
             mapResolution != mapResolutionLast || mapType != mapTypeLast || apiKey != apiKeyLast))
        {
            rect = GetComponent<RawImage>().rectTransform.rect;
            mapWidth = (int)rect.width;
            mapHeight = (int)rect.height;

            StartCoroutine(GetGoogleMap());
            updateMap = false;
        }
    }

    IEnumerator GetGoogleMap()
    {
        string url =
            "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom +
            "&size=" + mapWidth + "x" + mapHeight +
            "&scale=" + (int)mapResolution +
            "&maptype=" + mapType +
            "&key=" + apiKey;

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            GetComponent<RawImage>().texture =
                ((DownloadHandlerTexture)www.downloadHandler).texture;

            latLast = lat;
            lonLast = lon;
            zoomLast = zoom;
            mapResolutionLast = mapResolution;
            mapTypeLast = mapType;
            apiKeyLast = apiKey;

            updateMap = true;
        }
        else
        {
            Debug.LogError(www.error);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        lastMouse = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging) return;

        Vector2 current = eventData.position;
        Vector2 delta = current - lastMouse;
        lastMouse = current;

        lat += delta.y * panSpeed;
        lon -= delta.x * panSpeed;

        lat = Mathf.Clamp(lat, -85f, 85f);

        updateMap = true;
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (eventData.scrollDelta.y == 0) return;

        zoom += eventData.scrollDelta.y > 0 ? 1 : -1;
        zoom = Mathf.Clamp(zoom, 1, 20);

        updateMap = true;
    }
}
