using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class WeatherSystem : MonoBehaviour
{
    [Header("Global")]
    public Material globalMaterial;
    public Light sunLight;
    public Material skyboxMaterial;
    public TMP_Text weatherText;

    [Header("Winter Assets")]
    public GameObject winterParticleSystem;
    public Volume winterVolume;

    [Header("Rain Assets")]
    public GameObject rainParticleSystem;
    public Volume rainVolume;

    [Header("Autumn Assets")]
    public GameObject autumnParticleSystem;
    public Volume autumnVolume;

    [Header("Summer Assets")]
    public ParticleSystem summerParticleSystem;
    public Volume summerVolume;

    private void Start()
    {
        Summer();
    }

    public void Winter()
    {
        globalMaterial.SetColor("_SnowColor", Color.white);

        globalMaterial.SetFloat("_SnowFade", 1f);

        globalMaterial.SetFloat("_Smoothness", 0.15f);

        winterParticleSystem.gameObject.SetActive(true);
        rainParticleSystem.gameObject.SetActive(false);
        autumnParticleSystem.gameObject.SetActive(false);

        sunLight.gameObject.transform.rotation = Quaternion.Euler(25, -30, 0);
        sunLight.intensity = 0.4f;


        winterVolume.gameObject.SetActive(true);
        summerVolume.gameObject.SetActive(false);
        autumnVolume.gameObject.SetActive(false);
        rainVolume.gameObject.SetActive(false);

    }

    public void Rain()
    {
        globalMaterial.SetColor("_SnowColor", new Color(0.495283f, 0.9143325f, 1f));

        globalMaterial.SetFloat("_SnowFade", 0.15f);

        globalMaterial.SetFloat("_Smoothness", 0.75f);

        winterParticleSystem.SetActive(false);
        rainParticleSystem.SetActive(true);
        autumnParticleSystem.SetActive(false);
        
        sunLight.gameObject.transform.rotation = Quaternion.Euler(37, -30, 0);
        sunLight.intensity = 0.7f;

        winterVolume.gameObject.SetActive(false);
        summerVolume.gameObject.SetActive(false);
        autumnVolume.gameObject.SetActive(false);
        rainVolume.gameObject.SetActive(true);
    }

    public void Autumn()
    {
        globalMaterial.SetColor("_SnowColor", new Color(0.6981132f, 0.3656818f, 0.1086685f));

        globalMaterial.SetFloat("_SnowFade", 0.7f);

        globalMaterial.SetFloat("_Smoothness", 0.15f);

        winterParticleSystem.SetActive(false);
        rainParticleSystem.SetActive(false);
        autumnParticleSystem.SetActive(true);

        sunLight.gameObject.transform.rotation = Quaternion.Euler(37, -30, 0);
        sunLight.intensity = 0.7f;

        winterVolume.gameObject.SetActive(false);
        summerVolume.gameObject.SetActive(false);
        autumnVolume.gameObject.SetActive(true);
        rainVolume.gameObject.SetActive(false);
    }

    public void Summer()
    {
        globalMaterial.SetFloat("_SnowFade", 0f);

        globalMaterial.SetFloat("_Smoothness", 0.15f);

        winterParticleSystem.SetActive(false);
        rainParticleSystem.SetActive(false);
        autumnParticleSystem.SetActive(false);

        sunLight.gameObject.transform.rotation = Quaternion.Euler(50, -30, 0);
        sunLight.intensity = 1f;

        winterVolume.gameObject.SetActive(false);
        summerVolume.gameObject.SetActive(true);
        autumnVolume.gameObject.SetActive(false);
        rainVolume.gameObject.SetActive(false);
    }
}
