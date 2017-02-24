using System;
using ObjCRuntime;

[assembly: LinkWith ("libSMS_SDK.a", LinkTarget.Simulator | LinkTarget.ArmV7s | LinkTarget.ArmV7, ForceLoad = true)] //, Frameworks = "MOBFoundationEx MOBFoundation", LinkerFlags = "-lz -licucore -lstdc -ObjC"
