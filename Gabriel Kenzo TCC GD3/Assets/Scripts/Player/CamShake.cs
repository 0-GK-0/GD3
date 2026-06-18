using Unity.Cinemachine;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    private CinemachineCamera cinemachineCamera;
    private float shakeTimer;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
        cinemachineBasicMultiChannelPerlin =
            cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void shakeCam(float intensity, float time)
    {
        cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;

        shakeTimer = time;
    }

    private void Update()
    {
        if(cinemachineBasicMultiChannelPerlin.AmplitudeGain > 0)
        {
            cinemachineBasicMultiChannelPerlin.AmplitudeGain -= 1/shakeTimer * Time.unscaledDeltaTime * 2;
        }
        else if (cinemachineBasicMultiChannelPerlin.AmplitudeGain < 0) cinemachineBasicMultiChannelPerlin.AmplitudeGain = 0f;
    }
}
