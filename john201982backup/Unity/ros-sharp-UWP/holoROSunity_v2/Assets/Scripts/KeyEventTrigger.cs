using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEventTrigger : MonoBehaviour
{
    public UnityEvent event1;
    public UnityEvent event2;
    public UnityEvent event3;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            event1.Invoke();
        }
        if (Input.GetKeyDown("2"))
        {
            event2.Invoke();
        }
        if (Input.GetKeyDown("3"))
        {
            event3.Invoke();
        }
    }
}
