using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Component")]
    private GameObject cam;
    public GameObject stateBG;
    public GameObject gameOverPanel;
    public GameObject jumpButton;
    

    [Header("Post Processing")]
    public Volume globalVolume;
    private VolumeProfile volumeProfile;
    private Vignette vignette;
    private float originalVignetteIntensity = 0;
    private float targetVignetteIntensity;
    private float transitionDuration = 1.5f; // Adjust this value to control the duration of the transition

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
        // Get the VolumeProfile of the global volume
        if (globalVolume != null)
        {
            volumeProfile = globalVolume.profile;

            // Get the Vignette component from the Volume Profile
            if (volumeProfile.TryGet(out vignette))
            {
                // Save the original Vignette intensity for reference
                originalVignetteIntensity = vignette.intensity.value;
            }
            else
            {
                Debug.LogWarning("Vignette effect not found in the Volume Profile!");
            }
        }
        else
        {
            Debug.LogWarning("Global Volume is not assigned to the script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update the Vignette intensity to the target value over time
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetVignetteIntensity, Time.deltaTime / transitionDuration);

    }

    public void SetVignetteIntensity(float intensity)
    {
        // Set the target Vignette intensity to the desired value
        targetVignetteIntensity = intensity;
    }

    public void ResetVignetteIntensity()
    {
        // Reset the Vignette intensity to its original value
        targetVignetteIntensity = originalVignetteIntensity;
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        cam.GetComponent<MoveRight1>().moveSpeed = 0f;
        stateBG.GetComponent<MoveRight1>().moveSpeed = 0f;
        SetVignetteIntensity(.5f);
        StartCoroutine(panelPopup(gameOverPanel));
    }

    public void retryButton()
    {
        gameOverPanel.SetActive(false);
    }

    IEnumerator panelPopup(GameObject go)
    {
        jumpButton.SetActive(false);
        yield return new WaitForSeconds(3f);

        go.SetActive(true);
    }
}
