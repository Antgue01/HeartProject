using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateShader : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Shader shader;
    void Awake()
    {
        img.material = new Material(shader);
    }
}
