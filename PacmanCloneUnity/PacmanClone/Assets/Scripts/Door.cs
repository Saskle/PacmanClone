using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float waitingTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(waitingTime);
        Destroy(gameObject);
    }
}
