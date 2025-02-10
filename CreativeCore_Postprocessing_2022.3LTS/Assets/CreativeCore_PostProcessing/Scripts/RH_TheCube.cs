using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RH_TheCube : MonoBehaviour
{
    public Volume localVomume;
    ColorAdjustments colAdj;
    private bool inColl = false;
    private float timer = 0;
    private float timeToWait = 4;
    public float colorChangeSpeed = 180;
    public AudioSource audio;
    private float audioVolume = 0.5f;
    private float audioSpeed = 0.1f;

    private void Start()
    {
        localVomume.profile.TryGet(out colAdj);
        audioVolume = 0.5f;
        audio.volume = audioVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (inColl)
        {
            timer += Time.deltaTime;
            if (timer > timeToWait)
            {

                colAdj.hueShift.value += Time.deltaTime * colorChangeSpeed;
                audio.volume += Time.deltaTime * audioSpeed;
                if (colAdj.hueShift.value == 180)
                {
                    colAdj.hueShift.value = -180;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            Debug.Log("1");
            inColl = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            Debug.Log("4");
            inColl = true;
            colAdj.hueShift.value = 0;
            timer = 0;
            audio.volume = audioVolume;
        }
    }
}
