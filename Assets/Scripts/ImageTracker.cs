//Script which controls the Images that are eing tracked by the SDK

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placedPrefabs;

    private Dictionary<string, GameObject> spawndprefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject prefab in placedPrefabs)
        {                                                            //Quaternion.identity
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, prefab.transform.rotation);
            newPrefab.name = prefab.name;
            spawndprefabs.Add(prefab.name, newPrefab);
            newPrefab.SetActive(false); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawndprefabs[trackedImage.name].SetActive(false);
        }

    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawndprefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach (GameObject obj in spawndprefabs.Values)
        {
            if (obj.name != name)
            {
                obj.SetActive(false);
            }
        }

    }

}
