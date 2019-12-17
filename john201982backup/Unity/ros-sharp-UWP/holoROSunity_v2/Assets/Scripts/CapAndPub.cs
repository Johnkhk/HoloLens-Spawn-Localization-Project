using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.XR.WSA.WebCam;

namespace RosSharp.RosBridgeClient
{
    public class CapAndPub : Publisher<Messages.Sensor.CompressedImage>
    {
        //// takephoto
        PhotoCapture photoCaptureObject = null;
        public static Texture2D targetTexture = null;
        public GameObject quad;

        ////picpub
        public string FrameId = "Camera";
        public uint resolutionWidth = 640;
        public uint resolutionHeight = 480;
        [Range(0, 100)]
        public int qualityLevel = 50;
        private Messages.Sensor.CompressedImage message;
        private Texture2D texture2D;
        private Rect rect;

        private void OnEnable()
        {
            //takephoto
            Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
            targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

            // Create a PhotoCapture object
            PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject)
            {
                photoCaptureObject = captureObject;
                CameraParameters cameraParameters = new CameraParameters();
                cameraParameters.hologramOpacity = 0.0f;
                cameraParameters.cameraResolutionWidth = cameraResolution.width;
                cameraParameters.cameraResolutionHeight = cameraResolution.height;
                cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

                    // Activate the camera
                    photoCaptureObject.StartPhotoModeAsync(cameraParameters, delegate (PhotoCapture.PhotoCaptureResult result)
                    {
                        // Take a picture
                        //yield WaitForSeconds(5);
                        photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
                    });
            });
            //picpub
            InitializeMessage();
           // UpdateMessage();
        }

        //picpub
        private void InitializeMessage()
        {
            message = new Messages.Sensor.CompressedImage();
        }

        void UpdateMessage()
        {
            texture2D = TakePhoto.targetTexture;
            message.data = texture2D.EncodeToJPG(qualityLevel);
            Publish(message);
        }
        /*void Update()
        {
            UpdateMessage();
        }*/


        ///takephoto
        void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
        {
            // Copy the raw image data into the target texture
            photoCaptureFrame.UploadImageDataToTexture(targetTexture);

            // Create a GameObject to which the texture can be applied
            //GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            Renderer quadRenderer = quad.GetComponent<Renderer>() as Renderer;



            quadRenderer.material.SetTexture("_MainTex", targetTexture);
            ///////////////////////////
            //publish



            //////////////////////////
            // Deactivate the camera
            photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
        }

        void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
        {
            // Shutdown the photo capture resource
            photoCaptureObject.Dispose();
            photoCaptureObject = null;
        }
        private void OnDisable()
        {
            Publish(message);
        }
    }
}
