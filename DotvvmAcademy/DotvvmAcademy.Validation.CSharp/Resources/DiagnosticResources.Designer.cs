﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotvvmAcademy.Validation.CSharp.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DiagnosticResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DiagnosticResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DotvvmAcademy.Validation.CSharp.Resources.DiagnosticResources", typeof(DiagnosticResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Member &apos;{0}&apos; has to be {1}..
        /// </summary>
        public static string IncorrectAccessModifierMessage {
            get {
                return ResourceManager.GetString("IncorrectAccessModifierMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect Access Modifier.
        /// </summary>
        public static string IncorrectAccessModifierTitle {
            get {
                return ResourceManager.GetString("IncorrectAccessModifierTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} &apos;{1}&apos; is missing..
        /// </summary>
        public static string MissingMemberMessage {
            get {
                return ResourceManager.GetString("MissingMemberMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing Member.
        /// </summary>
        public static string MissingMemberTitle {
            get {
                return ResourceManager.GetString("MissingMemberTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} &apos;{1}&apos; is redundant..
        /// </summary>
        public static string RedundantMemberMessage {
            get {
                return ResourceManager.GetString("RedundantMemberMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redundant Member.
        /// </summary>
        public static string RedundantMemberTitle {
            get {
                return ResourceManager.GetString("RedundantMemberTitle", resourceCulture);
            }
        }
    }
}
