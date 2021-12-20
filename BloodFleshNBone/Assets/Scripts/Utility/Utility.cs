using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static float IntergrateArea(this AnimationCurve curve, int samplingPoint = 20)
    {
        var sampleWidth = (curve.keys[curve.length - 1].time - curve.keys[0].time) / samplingPoint;
        var samplingValue = (curve.Evaluate(curve.keys[curve.length - 1].time) + curve.Evaluate(curve.keys[0].time)) / 2;
        for (int i = 1; i < samplingPoint; i++)
        {
            samplingValue += curve.Evaluate(curve.keys[0].time + (i * sampleWidth));
        }
        return samplingValue * sampleWidth;
    }
}
