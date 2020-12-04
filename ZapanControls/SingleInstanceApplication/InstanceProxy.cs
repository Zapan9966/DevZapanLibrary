using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;

namespace ZapanControls.SingleInstanceApplication
{
    /// <summary>
    /// shared object for processes
    /// </summary>
    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Cannot be static")]
    internal sealed class InstanceProxy : MarshalByRefObject
    {
        /// <summary>
        /// Gets a value indicating whether this instance is first instance.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is first instance; otherwise, <c>false</c>.
        /// </value>
        public static bool IsFirstInstance { get; internal set; }

        /// <summary>
        /// Gets the command line args.
        /// </summary>
        /// <value>The command line args.</value>
        public static string[] CommandLineArgs { get; internal set; }

        /// <summary>
        /// Sets the command line args.
        /// </summary>
        /// <param name="isFirstInstance">if set to <c>true</c> [is first instance].</param>
        /// <param name="commandLineArgs">The command line args.</param>
        [SuppressMessage("Microsoft.Performance", "CA1822")]
        public void SetCommandLineArgs(bool isFirstInstance, string[] commandLineArgs)
        {
            IsFirstInstance = isFirstInstance;
            CommandLineArgs = commandLineArgs;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class InstanceCallbackEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceCallbackEventArgs"/> class.
        /// </summary>
        /// <param name="isFirstInstance">if set to <c>true</c> [is first instance].</param>
        /// <param name="commandLineArgs">The command line args.</param>
        internal InstanceCallbackEventArgs(bool isFirstInstance, string[] commandLineArgs)
        {
            IsFirstInstance = isFirstInstance;
            CommandLineArgs = commandLineArgs;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is first instance.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is first instance; otherwise, <c>false</c>.
        /// </value>
        public bool IsFirstInstance { get; private set; }

        /// <summary>
        /// Gets or sets the command line args.
        /// </summary>
        /// <value>The command line args.</value>
        public string[] CommandLineArgs { get; private set; }
    }
}
