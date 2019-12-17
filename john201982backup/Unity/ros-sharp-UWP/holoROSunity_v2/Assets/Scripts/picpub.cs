using UnityEngine;
namespace RosSharp.RosBridgeClient
{
    public class picpub : Publisher<Messages.Sensor.CompressedImage>
    {

        // public PhotoCapture ImageCamera;
        public string FrameId = "Camera";
        public uint resolutionWidth = 1280;
        public uint resolutionHeight = 720;
        [Range(0, 100)]
        public int qualityLevel = 50;
        private Messages.Sensor.CompressedImage message;
        private Texture2D texture2D;
        private Rect rect;



        /*
        private void OnEnable()
        {
            InitializeGameObject();
            InitializeMessage();
           // UpdateMessage();
        }*/

        public static bool ispublish = false;

        protected override void Start()
        {
            base.Start();
            InitializeGameObject();
            InitializeMessage();
           // UpdateMessage();//
            


    }
       
        public void Settofalse()
        {
            ispublish = false;
        }
        public void Settotrue()
        {
            ispublish = true;
        }

        public void Update()
        {

           if (ispublish)
            {
                UpdateMessage();
            }
         
        }
        



        private void InitializeGameObject()
        {
            rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
            //////
            //targetTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        }

        private void InitializeMessage()
        {
            message = new Messages.Sensor.CompressedImage();
            //message.header.frame_id = FrameId;
            //message.height = resolutionHeight;
            //message.width = resolutionWidth;
            //message.format = "jpeg";

        }
        
        public void UpdateMessage()
        {
            ///
            //texture2D.ReadPixels(rect, 0, 0);
            ///
            texture2D = TakePhoto.targetTexture;
            message.data = texture2D.EncodeToJPG(qualityLevel);
            Publish(message);
            
        }

        public void publishboi()
        {
            //Publish(message);
            texture2D = TakePhoto.targetTexture;
            message.data = texture2D.EncodeToJPG(qualityLevel);
             Publish(message);
        }

        /*
            void Update()
            {

            
                UpdateMessage();
            
            
                
            
                
            }
            */

    }

}

