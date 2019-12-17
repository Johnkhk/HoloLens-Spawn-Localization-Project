using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject cubee;
    //public static Vector3 spawn_postition
    //public Vector3 somedood;

    PoseSubscriber Posesubscibers;

    //PoseSubscriber PoseSubscriber;
    //float wowowo = PoseSubscriber.position.x;
    //conversion
    // float xo = 1;
    //float yo = 2;
    //float zo = 3;
    // private Vector3 position.x = PoseSubscriber.position.x;
   /* IEnumerator coroutine()
    {
        yield return new WaitForSeconds(2);
        Instantiate(cubee, spawnpos, PoseSubscriber.rotation);
    }*/
    Vector3 spawnpos;
    Quaternion spawnrot;
    
    private void Start()
    {
        /*
        spawnpos.x = -PoseSubscriber.position.z;
        spawnpos.y = -PoseSubscriber.position.x;
        spawnpos.z = PoseSubscriber.position.y;
        */
    }

    //private Vector3 spawnpos = new Vector3(-PoseSubscriber.position.y, PoseSubscriber.position.z, PoseSubscriber.position.x);

    //spawn_position.x = PoseSubscriber.position.x;
    //Camera.main.transform.position.x


    //public Vector3 spawnpos = (Pose)
    bool cubespawned=true;
    public void spawn()
    {        
        Vector3 tag_position = PoseSubscriber.position;
        Quaternion tag_rotation = PoseSubscriber.rotation;

        // Conversion here
        tag_position.x = PoseSubscriber.position.x;
        tag_position.y = PoseSubscriber.position.y;
        tag_position.z = PoseSubscriber.position.z;

        Vector3 camera_main_position = Camera.main.transform.position;

        spawnpos.x = camera_main_position.x + tag_position.x;
        spawnpos.y = camera_main_position.y + tag_position.y;
        spawnpos.z = camera_main_position.z + tag_position.z;

        spawnrot = tag_rotation;

        //spawnrot.x = Camera.main.transform.rotation.x - PoseSubscriber.rotation.z;
        //spawnrot.y = Camera.main.transform.rotation.y - PoseSubscriber.rotation.x;
        //spawnrot.z = Camera.main.transform.rotation.z - PoseSubscriber.rotation.y;
        //spawnrot.w = Camera.main.transform.rotation.w - PoseSubscriber.rotation.w;

        Debug.Log("tag x=" + tag_position.x);
        Debug.Log("tag y=" + tag_position.y);
        Debug.Log("tag z=" + tag_position.z);

        Debug.Log("camera x= " + camera_main_position.x);
        Debug.Log("camera y= " + camera_main_position.y);
        Debug.Log("camera z= " + camera_main_position.z);

        //Debug.Log(PoseSubscriber.position);
        //Debug.Log(PoseSubscriber.rotation);
        //Debug.Log(spawnpos);
        GameObject object1 = GameObject.Find("turtlebot(Clone)");
        if (object1 != null)
           Destroy(object1);

     Instantiate(cubee, spawnpos, spawnrot);
        //Destroy(cubee);
        //cubespawned = true;

    }
}

/*   spawn_position.x = - position.y;
                    spawn_position.y = position.z;
                    spawn_position.z = position.x;
                    spawn_rotation = rotation;
*/