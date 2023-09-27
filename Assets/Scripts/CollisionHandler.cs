using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] float levelReloadTime = 2.5f;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;    

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();        
    }

    private void OnCollisionEnter(Collision other) {
        if (isTransitioning || collisionDisabled) { return; }
            switch (other.gameObject.tag) {
                case "Friendly":
                    print("This is the Launch pad and it is friendly to us!!");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }                
    }

    public void SetCollisionState() {
        collisionDisabled = !collisionDisabled;
    }

    void StartSuccessSequence() {
        
        SFXPlayer(successSound);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(LoadNextLevel), levelReloadTime);
        isTransitioning = true;
    }

    void StartCrashSequence() {
        
        SFXPlayer(crashSound);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(ReloadLevel), levelReloadTime);
        isTransitioning = true;
    }

    void ReloadLevel() {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextLevel() {
        
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel == SceneManager.sceneCountInBuildSettings) {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }

    void SFXPlayer(AudioClip audioClip) {
        audioSource.Stop();
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(audioClip);
        }
        else {
            audioSource.Stop();
        }
    }

    
}
