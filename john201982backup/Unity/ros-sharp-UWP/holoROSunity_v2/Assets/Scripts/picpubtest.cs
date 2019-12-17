using UnityEngine;
namespace RosSharp.RosBridgeClient
{
    public class picpubtest : Publisher<Messages.Sensor.CompressedImage>
    {





        // public PhotoCapture ImageCamera;
        public string FrameId = "Camera";
        public uint resolutionWidth = 640;
        public uint resolutionHeight = 480;
        [Range(0, 100)]
        public int qualityLevel = 50;
        private Messages.Sensor.CompressedImage message;
        private Texture2D texture2D;
        private Rect rect;


        protected override void Start()
        {
            InitializeGameObject();
            InitializeMessage();
            //UpdateMessage();
        }

        /*

        protected override void Start()
        {
            base.Start();
            InitializeGameObject();
            InitializeMessage();
            //UpdateMessage();

        }*/

        private void InitializeGameObject()
        {
            //rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
            //ImageCamera.targetTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        }

        private void InitializeMessage()
        {
            message = new Messages.Sensor.CompressedImage();
            //message.header.frame_id = FrameId;
            //message.height = resolutionHeight;
            //message.width = resolutionWidth;
            //message.step = 

        }





        void UpdateMessage()
        {

            texture2D = TakePhoto.targetTexture;
            message.data = texture2D.EncodeToJPG(qualityLevel);
            Publish(message);
        }

        

        
            void Update()
            {
                UpdateMessage();
            }
        
    


    }

}

