using System;
using ObjCRuntime;

[assembly: LinkWith ("libSMSSDKUI.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, LinkerFlags = "-lz -licucore -lstdc++ -ObjC")]
