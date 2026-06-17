using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Directional Light")]
    public Light sun;

    [Header("Cycle Settings")]
    [Tooltip("낮→밤→낮 한 바퀴 도는 시간(초)")]
    public float cycleDuration = 20f;

    private float currentTime;

    private void Update()
    {
        if (sun == null) return;

        // 시간 증가
        currentTime += Time.deltaTime;

        // 0 ~ 1 반복
        float normalizedTime = (currentTime % cycleDuration) / cycleDuration;

        // 0 ~ 360도 회전
        float sunAngle = normalizedTime * 360f;

        transform.rotation = Quaternion.Euler(sunAngle - 90f, 170f, 0f);

        // 빛 세기 조절
        float intensity = Mathf.Clamp01(
            Mathf.Cos((normalizedTime - 0.25f) * Mathf.PI * 2f)
        );

        sun.intensity = intensity;
    }
}