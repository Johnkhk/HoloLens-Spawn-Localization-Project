
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.XR.WSA.WebCam;
using RosSharp.RosBridgeClient;
public class TakePhoto : MonoBehaviour
{
    PhotoCapture photoCaptureObject = null;
    public static Texture2D targetTexture = null;
    public GameObject quad;
    public picpub picpub;
    public ObjectSpawn ObjectSpawn;
    public PoseSubscriber PoseSubscriber;
    //private IEnumerator coroutine;

    // Use this for initialization
    public void Start()
    {
        //StartCoroutine(coroutine());
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

        // Create a PhotoCapture object
        PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject) {
            photoCaptureObject = captureObject;
            CameraParameters cameraParameters = new CameraParameters();
            cameraParameters.hologramOpacity = 0.0f;
            cameraParameters.cameraResolutionWidth = 1280;
            cameraParameters.cameraResolutionHeight = 720;
            cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

            // Activate the camera
            photoCaptureObject.StartPhotoModeAsync(cameraParameters, delegate (PhotoCapture.PhotoCaptureResult result) {
                // Take a picture
                //DOOOAAAAIFFFFFHERERERERERE
                //photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
            });
        });
    }

    public void takepic()
    {
        photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
      // StartCoroutine(coroutine());
        
    }
    /*
    private IEnumerator coroutine()
    {
        yield return new WaitForEndOfFrame();
        ObjectSpawn.spawn();
        
            
    }*/

    void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        photoCaptureFrame.UploadImageDataToTexture(targetTexture);
        Renderer quadRenderer = quad.GetComponent<Renderer>() as Renderer;
        quadRenderer.material.SetTexture("_MainTex", targetTexture);
        //photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
        picpub.publishboi();
        //ObjectSpawn.spawn();
        //PoseSubscriber.method();
        //if(PoseSubscriber.isMessageReceived==true)
        //{ ObjectSpawn.spawn(); }
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        // Shutdown the photo capture resource
       photoCaptureObject.Dispose();
       photoCaptureObject = null;
    }
}