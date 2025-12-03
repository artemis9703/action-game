using UnityEngine;
using System.Collections.Generic;

public class LocationHistoryTracker : MonoBehaviour
{
    public static LocationHistoryTracker Instance;
    private readonly HashSet<LocationSO> locationsVisited = new HashSet<LocationSO>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public void RecordLocation(LocationSO locationSO)
    {
        if (locationsVisited.Add(locationSO))
        {
            Debug.Log("Just visited " + locationSO.displayName);
        }
    }

    public bool HasVisited(LocationSO locationSO)
    {
        return locationsVisited.Contains(locationSO);
    }
}
