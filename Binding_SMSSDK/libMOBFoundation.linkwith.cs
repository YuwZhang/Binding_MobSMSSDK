using System;
using ObjCRuntime;

[assembly: LinkWith ("libMOBFoundation.a", LinkTarget.ArmV7s | LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
