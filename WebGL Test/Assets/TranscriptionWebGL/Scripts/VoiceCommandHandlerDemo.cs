using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Devden.STT
{
    public class VoiceCommandHandlerDemo : MonoBehaviour
    {
        [SerializeField] Toggle listenContinuously;
        [SerializeField] Transform cube;

        float rotateSpeed;
        private void Start()
        {
            //Sets the gameobject name, very important if you want to call function from js 
            TranscriptionHandler.SetGameObjectName(transform.gameObject.name);
        }

        private void Update()
        {
            cube.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        public void StartListening()
        {
            TranscriptionHandler.RunSpeechRecognition(listenContinuously.isOn);
        }

        public void StopListening()
        {
            TranscriptionHandler.StopRecognition();
        }

        //Receives result from speech recognition, use the same function name in case it needs to be used elsewhere.
        public void Result(string text)
        {
            var result = text.ToLower();

            switch (result)
            {
                case "rotate":
                    rotateSpeed = 5;
                    break;

                case "left":
                    cube.Translate(new Vector3(-1, 0, 0), Space.World);
                    break;

                case "right":
                    cube.Translate(new Vector3(1, 0, 0), Space.World);
                    break;

                case "rotate faster":
                    rotateSpeed = 20;
                    break;

            }
        }
    }
}