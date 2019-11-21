using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;

public class EyebrowController : MonoBehaviour
{
    [SerializeField] private CubismParameter brow_r_form;
    [SerializeField] private CubismParameter brow_l_form;
    private float move = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (move <= -1f)
            {
                move = -1f;
            }

            move -= 0.1f;
        }
        else
        {
            if (move >= 0f)
            {
                move = 0f;
            }

            move += 0.1f;
        }

        SetParameter(brow_r_form, move);
        SetParameter(brow_l_form, move);
    }

    void SetParameter(CubismParameter parameter, float value)
    {
        if (parameter != null)
        {
            parameter.Value = Mathf.Clamp(value, parameter.MinimumValue, parameter.MaximumValue);
        }
    }
}
