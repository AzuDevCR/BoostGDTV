using UnityEngine;

public class Movement : MonoBehaviour
{
    // Params - Serialize Fields

    // Catching references - GetComponent<>();

    // State private instance members - variables

    [SerializeField] float thrustSpeed = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    Rigidbody rb;
    AudioSource audioSource;   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessRotation() {
        if (GetComponent<CamSwitch>().getCam1State()) {
            cam1Rotation();
        }
        else {
            cam2Rotation();
        }
        
    }

    void cam1Rotation() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            ApplyRotation(rotationSpeed);
            if (!leftBooster.isPlaying) {
                leftBooster.Play();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationSpeed);
            if (!rightBooster.isPlaying) {
                rightBooster.Play();
            }
        }
    }

    void cam2Rotation() {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            ApplyRotation(rotationSpeed);
            if (!leftBooster.isPlaying) {
                leftBooster.Play();
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            ApplyRotation(-rotationSpeed);
            if (!rightBooster.isPlaying) {
                rightBooster.Play();
            }
        }
    }

    void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            if (!audioSource.isPlaying) {                
                audioSource.PlayOneShot(mainEngine);
            if (!mainBooster.isPlaying) {
                    mainBooster.Play();
                }
            }           
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
        else {
            audioSource.Stop();
        }

    }
}
