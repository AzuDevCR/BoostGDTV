using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    bool cam1Active = true;
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            CameraChange();
        }
    }

    void CameraChange() {
        if (cam1.isActiveAndEnabled) {
            setCam2();
        }
        else {
            setCam1();
        }
    }

    void setCam2() {
        cam2.gameObject.SetActive(true);
        cam2.GetComponent<AudioListener>().enabled = true;

        cam1.gameObject.SetActive(false);
        cam1.GetComponent<AudioListener>().enabled = false;
        cam1Active = false;
    }

    void setCam1() {
        cam2.gameObject.SetActive(false);
        cam2.GetComponent<AudioListener>().enabled = false;

        cam1.gameObject.SetActive(true);
        cam1.GetComponent<AudioListener>().enabled = true;
        cam1Active = true;
    }

    public bool getCam1State() {
        return cam1Active;
    }
}
