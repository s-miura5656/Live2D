using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class ParamatorFace : MonoBehaviour
{
    private CubismModel _model;
    private float _t;

    private void Start()
    {
        _model = this.FindCubismModel();
    }

    private void LateUpdate()
    {
        _t += (Time.deltaTime * 1f);
        var value = Mathf.Sin(_t) * 5f;

        var parameter_1 = _model.Parameters[14];
        var parameter_2 = _model.Parameters[16];

        parameter_1.Value = value;
        parameter_2.Value = value;
    }
}
