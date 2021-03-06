//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Action_Boolean p_dpadClick_dpadUp;
        
        private static SteamVR_Action_Boolean p_dpadClick_dpadDown;
        
        private static SteamVR_Action_Boolean p_dpadClick_dpadLeft;
        
        private static SteamVR_Action_Boolean p_dpadClick_dpadRight;
        
        private static SteamVR_Action_Pose p_dpadClick_pose;
        
        public static SteamVR_Action_Boolean dpadClick_dpadUp
        {
            get
            {
                return SteamVR_Actions.p_dpadClick_dpadUp.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean dpadClick_dpadDown
        {
            get
            {
                return SteamVR_Actions.p_dpadClick_dpadDown.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean dpadClick_dpadLeft
        {
            get
            {
                return SteamVR_Actions.p_dpadClick_dpadLeft.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean dpadClick_dpadRight
        {
            get
            {
                return SteamVR_Actions.p_dpadClick_dpadRight.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Pose dpadClick_pose
        {
            get
            {
                return SteamVR_Actions.p_dpadClick_pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.dpadClick_dpadUp,
                    SteamVR_Actions.dpadClick_dpadDown,
                    SteamVR_Actions.dpadClick_dpadLeft,
                    SteamVR_Actions.dpadClick_dpadRight,
                    SteamVR_Actions.dpadClick_pose};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.dpadClick_dpadUp,
                    SteamVR_Actions.dpadClick_dpadDown,
                    SteamVR_Actions.dpadClick_dpadLeft,
                    SteamVR_Actions.dpadClick_dpadRight,
                    SteamVR_Actions.dpadClick_pose};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[0];
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[0];
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.dpadClick_pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.dpadClick_dpadUp,
                    SteamVR_Actions.dpadClick_dpadDown,
                    SteamVR_Actions.dpadClick_dpadLeft,
                    SteamVR_Actions.dpadClick_dpadRight};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[0];
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[0];
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[0];
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.dpadClick_dpadUp,
                    SteamVR_Actions.dpadClick_dpadDown,
                    SteamVR_Actions.dpadClick_dpadLeft,
                    SteamVR_Actions.dpadClick_dpadRight};
        }
        
        private static void PreInitActions()
        {
            SteamVR_Actions.p_dpadClick_dpadUp = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/dpadClick/in/dpadUp")));
            SteamVR_Actions.p_dpadClick_dpadDown = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/dpadClick/in/dpadDown")));
            SteamVR_Actions.p_dpadClick_dpadLeft = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/dpadClick/in/dpadLeft")));
            SteamVR_Actions.p_dpadClick_dpadRight = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/dpadClick/in/dpadRight")));
            SteamVR_Actions.p_dpadClick_pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/dpadClick/in/pose")));
        }
    }
}
