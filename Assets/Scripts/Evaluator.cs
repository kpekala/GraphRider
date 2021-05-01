using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;

//This class provides method for evaluating function at given point.
public class Evaluator
{
    private Expression expression;
    private Argument xArgument;

    public Evaluator(string functionText)
    {
        xArgument = new Argument("x",0);
        expression = new Expression(functionText,xArgument);
    }

    public float Evaluate(float x)
    {
        xArgument.setArgumentValue(x);
        return (float) expression.calculate();
    }
}
