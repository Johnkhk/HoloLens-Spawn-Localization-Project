using UnityEngine;
using System.Linq;

namespace RosSharp.RosBridgeClient
{
    public class PoseSubscriber : Subscriber<Messages.Geometry.Pose>
    {
        public TextMesh mytext;
        public static Vector3 position;
        public static Quaternion rotation;
        public bool isMessageReceived;
        public bool isObjectSpawned;
        public ObjectSpawn ObjectSpawn;
        
            /*
        protected override void Start()
        {
            base.Start();

        }
        */

        /*
        private void Update()
        {
            while (isMessageReceived)
            {
                ObjectSpawn.spawn();
                isMessageReceived = false;
            }
              
        }*/

        //protected overrude void
        public void method()
        {
            
            
            
        }
        

        protected override void ReceiveMessage(Messages.Geometry.Pose message)
        {
            position = GetPosition(message);//.Ros2Unity();
            rotation = GetRotation(message);//.Ros2Unity();
            isMessageReceived = true;
            Debug.Log("x=" + position.x);
            Debug.Log("y=" + position.y);
            Debug.Log("z=" + position.z);
            // Debug.Log(position);
            //Debug.Log(rotation);

        }
        /*
        public void ProcessMessage()
        {
            transform.position = position;
            transform.rotation = rotation;
            Debug.Log("REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        }*/

        private Vector3 GetPosition(Messages.Geometry.Pose message)
        {
            return new Vector3(
                message.position.x,
                message.position.y,
                message.position.z);
            //Debug.Log("11111111111111111111111111111111111111111111");
        }

        private Quaternion GetRotation(Messages.Geometry.Pose message)
        {
            return new Quaternion(
                message.orientation.x,
                message.orientation.y,
                message.orientation.z,
                message.orientation.w);
            //Debug.Log("2222222222222222222222222222222222222222222");
        }

        
    }
}