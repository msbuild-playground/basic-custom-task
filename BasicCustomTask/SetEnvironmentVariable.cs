using System;
using Microsoft.Build.Framework;

namespace BasicCustomTask {

	public class SetEnvironmentVariable : ITask
    {
		public IBuildEngine BuildEngine { set; get; } = null;
		public ITaskHost HostObject { set; get; } = null;

		[Required]
		public string Name { set; get; } = null;

		[Required]
		public string Value { set; get; } = null;

		public bool Execute()
        {                        
            System.Environment.SetEnvironmentVariable(Name, Value);

			var message = string.Format("Environment Variable {0} set to {1}", Name, Value);
            var args = new BuildMessageEventArgs(
                message, string.Empty, "SetEnvironmentVariable", MessageImportance.Normal);
            BuildEngine.LogMessageEvent(args);
           
            return true;
        }
    }
}
