using UnityEngine;
using UnityEngine.UI;

namespace MovementControls
{
    public class CameraControl : MonoBehaviour
    {
        public float movementSpeed = 1.0f;
        public float rotationSpeed = 1.0f;
        public Animator speedText;

        private float speedInput;

        private void Update()
        {
            if (Input.GetAxis("Speed") != 0) speedInput = Input.GetAxis("Speed");
            if (Input.GetButtonUp("Speed"))
            {
                movementSpeed += speedInput;
                if (movementSpeed < 1) movementSpeed = 1;
                rotationSpeed += speedInput;
                if (rotationSpeed < 1) movementSpeed = 1;
                speedText.ResetTrigger("Fade");
                speedText.SetTrigger("Fade");
                speedText.GetComponent<Text>().text = string.Format("Speed: {0}X", movementSpeed);
            }

            // forwards
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.position = transform.position + transform.forward * Time.deltaTime * movementSpeed;
            }
            // backwards
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.position = transform.position - transform.forward * Time.deltaTime * movementSpeed;
            }

            // right
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.position = transform.position + transform.right * Time.deltaTime * movementSpeed;
            }
            // left
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.position = transform.position - transform.right * Time.deltaTime * movementSpeed;
            }

            // up
            if (Input.GetAxis("Y Axis") > 0)
            {
                transform.position = transform.position + transform.up * Time.deltaTime * movementSpeed;
            }
            // down
            else if (Input.GetAxis("Y Axis") < 0)
            {
                transform.position = transform.position - transform.up * Time.deltaTime * movementSpeed;
            }

            // mouse left click
            if (Input.GetAxis("Fire2") > 0)
            {
                var currentRotation = transform.rotation.eulerAngles;
                // move mouse
                transform.rotation =
                    Quaternion.Euler(new Vector3(currentRotation.x - Input.GetAxis("Mouse Y")*rotationSpeed,
                        currentRotation.y + Input.GetAxis("Mouse X")*rotationSpeed,
                        currentRotation.z));
            }
        }
    }
}