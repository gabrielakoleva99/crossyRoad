using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script generates day and night in game where during the night its darker and more difficult to see
// script modifies from youtube tutorial
[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightPreset lightPreset;
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    private void Update()
    {
        if (lightPreset == null)
            return;
        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24;
            UpdateLight(TimeOfDay / 24f);
        }
    }

    private void UpdateLight(float timePercent)
    {
        RenderSettings.ambientLight = lightPreset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = lightPreset.FogColor.Evaluate(timePercent);

        if(DirectionalLight!= null )
        {
            DirectionalLight.color = lightPreset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) -90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)

            return;
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
