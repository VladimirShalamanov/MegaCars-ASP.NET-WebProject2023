﻿//namespace MegaCarsSystem.Common
//{
//    using System.Reflection;

//    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
//    public class MultipleButtonAttribute : ActionNameSelectorAttribute
//    {
//        public string Name { get; set; }
//        public string Argument { get; set; }

//        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
//        {
//            var isValidName = false;
//            var keyValue = string.Format("{0}:{1}", Name, Argument);
//            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

//            if (value != null)
//            {
//                controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
//                isValidName = true;
//            }

//            return isValidName;
//        }
//    }
//}