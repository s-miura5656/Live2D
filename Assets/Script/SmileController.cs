using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class SmileController : MonoBehaviour
{
    [SerializeField] private CubismParameter smile_r = null;
    [SerializeField] private CubismParameter smile_l = null;
    [SerializeField] private CubismParameter eye_open_r = null;
    [SerializeField] private CubismParameter eye_open_l =null;
    private CubismEyeBlinkController eye_blink_script = null;
    private float move_smile = 0f;
    private float move_eye = 0f;

    // Start is called before the first frame update
    void Start()
    {
        eye_blink_script = GetComponent<CubismEyeBlinkController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            eye_blink_script.enabled = false;

            if (move_smile >= smile_r.MaximumValue)
            {
                move_smile = smile_r.MaximumValue;
            }

            if (move_eye <= eye_open_r.MinimumValue)
            {
                move_eye = eye_open_r.MinimumValue;
            }

            move_smile += 0.1f;
            move_eye -= 0.1f;
        }
        else
        {
            if (move_smile <= smile_r.MinimumValue)
            {
                move_smile = smile_r.MinimumValue;
                eye_blink_script.enabled = true;
            }

            if (move_eye >= eye_open_r.MaximumValue)
            {
                move_eye = eye_open_r.MaximumValue;
            }

            move_smile -= 0.1f;
            move_eye += 0.1f;
        }

        SetParameter(eye_open_r, move_eye);
        SetParameter(eye_open_l, move_eye);
        SetParameter(smile_r, move_smile);
        SetParameter(smile_l, move_smile);
    }

    void SetParameter(CubismParameter parameter, float value)
    {
        if (parameter != null)
        {
            parameter.Value = Mathf.Clamp(value, parameter.MinimumValue, parameter.MaximumValue);
        }
    }
}
