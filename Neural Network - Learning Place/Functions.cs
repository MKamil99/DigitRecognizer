﻿using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    class Functions
    {
        public static double Alpha { get; set; } = 0.8;

        public static double CalculateError(List<double> outputs, int row, double[][] expectedresults) // funkcja błędu
        {
            double error = 0;
            for (int i = 0; i < outputs.Count; i++)
                error += Math.Pow(outputs[i] - expectedresults[row][i], 2);
            return error;
        }

        public static double InputSumFunction(List<Synapse> Inputs, double bias = 0)
        // funkcja wejścia: suma iloczynów wag synaps wchodzących i wartości wyjściowych neuronów warstwy poprzedniej
        {
            double input = 0;
            foreach (Synapse syn in Inputs) 
                input += syn.GetOutput();
            input += bias;
            return input;
        }

        public static double BipolarLinearFunction(double input) // funkcja aktywacji: bipolarna liniowa...
            => (1 - Math.Pow(Math.E, -Alpha * input)) / (1 + Math.Pow(Math.E, -Alpha * input));

        public static double BipolarDifferential(double input) // ... i jej pochodna
            => (2 * Alpha * Math.Pow(Math.E, -Alpha * input)) / (Math.Pow(1 + Math.Pow(Math.E, -Alpha * input), 2));
    }
}