using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocationVisitedTrigger : MonoBehaviour
{
    [SerializeField] private LocationSO locationVisited;
    [SerializeField] private bool destroyOnTouch = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LocationHistoryTracker.Instance.RecordLocation(locationVisited);
            if (destroyOnTouch == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
