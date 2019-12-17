using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // this namespace makes the magic, tho
using UnityEngine.XR.WSA.Input;

public class OnClickCube : MonoBehaviour
{
    GestureRecognizer recognizer;
    private void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);

        recognizer.TappedEvent += Recognizer_TappedEvent;
        recognizer.StartCapturingGestures();
    }
    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapcount, Ray headRay)
    {
        //if(tapcount == 1)
        //{
            anEvent.Invoke();
        //}
        //anEvent.Invoke();
        //anEvent.Invoke();
        //if(tapcount == 2)
        //{
          //  anotherEvent.Invoke();
        //}
        //anotherEvent.Invoke();
    }


    [SerializeField] UnityEvent anEvent; // puts an easy to setup event in the inspector and anEvent references it so you can .Invoke() it
   // [SerializeField] UnityEvent anotherEvent;
    // This captures a click as long as you have a collider, even if it's set to just be a trigger, and nothing blocking it.
    // However, it will still capture even if a Gui button is on top of it, so make sure you aren't checking this while also checking Gui
    // Only other colliders block and it's not as manageable as Canvas Groups.


    /*

    private void OnMouseDown()
    {
        //print("You clicked the cube!");
        anEvent.Invoke();
        anEvent.Invoke(); // Triggers the events you have setup in the inspector
    }
    */

    //OnInputClicked


    // This is the first method the event is setup to do, the second audio part needed no script to just do a one shot effect, thanks to the event system.
    // You just set up the Event in the inspector for easy peasy, but the UnityEvent could also be coded the same way if needed.
    public void EventClick() // methods have to be public void to be used by UnityEvents, they can't really return anything either, as far as I know... At least I don't know how an event will capture the return...
    {
        print("Which also triggered this method as a UnityEvent!");
    }
 


}