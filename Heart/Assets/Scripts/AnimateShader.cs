using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("Scripts/AnimateShader")]
public class AnimateShader : MonoBehaviour
{
    [SerializeField] string[] names;
    [SerializeField] PlayableAsset[] anims;
    [SerializeField] Image img;
    Dictionary<string, PlayableAsset> assets;
    private void Start()
    {
        assets = new Dictionary<string, PlayableAsset>();
        for (int i = 0; i < names.Length; i++)
        {
            assets.Add(names[i], anims[i]);
        }
    }

    public void Play(string animation)
    {
        if (assets.TryGetValue(animation, out var asset))
            StartCoroutine(PlayCorroutine(asset));
    }

    IEnumerator PlayCorroutine(PlayableAsset animation)
    {

        float[] times = new float[animation.properties.Length];
        for (int i = 0; i < times.Length; i++)

            while (times[i] <= animation.curve[i].keys[animation.curve[i].length - 1].time)
            {
                times[i] += Time.deltaTime;
                float eval = animation.curve[i].Evaluate(times[i]);
                img.material.SetFloat(animation.properties[i], animation.curve[i].Evaluate(times[i]));
                yield return null;
            }
    }

}
