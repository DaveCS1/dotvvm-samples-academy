﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotvvmAcademy.Steps.Validation.Validators {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ValidationErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal ValidationErrorMessages() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DotvvmAcademy.Steps.Validation.Validators.ValidationErrorMessages", typeof(ValidationErrorMessages).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The class {0} was not found!.
        /// </summary>
        public static string ClassNotFound {
            get {
                return ResourceManager.GetString("ClassNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The {0} property {1} must contain binding in the following format: {{command: Something()}}.
        /// </summary>
        public static string CommandBindingExpected {
            get {
                return ResourceManager.GetString("CommandBindingExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to You need to add empty parenthesis after the {0} method..
        /// </summary>
        public static string CommandDoesNotHaveParenthesis {
            get {
                return ResourceManager.GetString("CommandDoesNotHaveParenthesis", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The command methods in the viewmodel must be public and must have the correct signature!.
        /// </summary>
        public static string CommandMethodError {
            get {
                return ResourceManager.GetString("CommandMethodError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to There should be {0} {1} html tag in the page!.
        /// </summary>
        public static string HtmlTagCountError {
            get {
                return ResourceManager.GetString("HtmlTagCountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The constructor of type {0} is not allowed!.
        /// </summary>
        public static string IllegalConstructorCall {
            get {
                return ResourceManager.GetString("IllegalConstructorCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The method {0} is not allowed!.
        /// </summary>
        public static string IllegalMethodCall {
            get {
                return ResourceManager.GetString("IllegalMethodCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The {0} method doesn&apos;t exist!.
        /// </summary>
        public static string MethodNotFound {
            get {
                return ResourceManager.GetString("MethodNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to You must call the {0} in the command binding!.
        /// </summary>
        public static string MethodWasNotCalled {
            get {
                return ResourceManager.GetString("MethodWasNotCalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The {0} doesn&apos;t specify the {1} property!.
        /// </summary>
        public static string MissingPropertyError {
            get {
                return ResourceManager.GetString("MissingPropertyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The {0} property was not found or doesn&apos;t have a correct type!.
        /// </summary>
        public static string PropertyNotFound {
            get {
                return ResourceManager.GetString("PropertyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Step type {0} ins`t supported!.
        /// </summary>
        public static string StepTypeExpected {
            get {
                return ResourceManager.GetString("StepTypeExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Each TextBox should bind to a different property in the viewmodel!.
        /// </summary>
        public static string TextBoxBindingsError {
            get {
                return ResourceManager.GetString("TextBoxBindingsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to There should be {0} {1} controls in the page!.
        /// </summary>
        public static string TypeControlCountError {
            get {
                return ResourceManager.GetString("TypeControlCountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Property {0} should be bind!.
        /// </summary>
        public static string ValueBindingError {
            get {
                return ResourceManager.GetString("ValueBindingError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The {0} property {1} must contain binding in the following format: {{value: Something}}.
        /// </summary>
        public static string ValueBindingExpected {
            get {
                return ResourceManager.GetString("ValueBindingExpected", resourceCulture);
            }
        }
    }
}
