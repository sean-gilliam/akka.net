//-----------------------------------------------------------------------
// <copyright file="MultiNodeFact.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using Xunit;

namespace Akka.Remote.TestKit
{
    /// <summary>
    /// TBD
    /// </summary>
    public class MultiNodeFactAttribute : FactAttribute
    {
        /// <summary>
        /// TBD
        /// </summary>
        public static Lazy<bool> ExecutedByMultiNodeRunner =
            new Lazy<bool>(() =>
            {
                var args = Environment.GetCommandLineArgs();
                if (args.Length == 0) return false;
                var firstArg = args[0];
                return firstArg.Contains("Akka.MultiNodeTestRunner") 
                    || firstArg.Contains("Akka.NodeTestRunner");
            });

        /// <summary>
        /// TBD
        /// </summary>
        public override string Skip
        {
            get
            {
                return ExecutedByMultiNodeRunner.Value
                    ? base.Skip
                    : "Must be executed by multi-node test runner";
            }
            set { base.Skip = value; }
        }
    }
}