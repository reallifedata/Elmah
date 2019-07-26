﻿#region License, Terms and Author(s)
//
// ELMAH - Error Logging Modules and Handlers for ASP.NET
// Copyright (c) 2004-9 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

namespace Elmah.Tests
{
    extern alias e;

    #region Imports

    using System;
    using System.Collections;
    using System.Linq;
    using System.Web;
    using Moq;
    using Xunit;
    using e::Elmah;

    #endregion

    public class ErrorGroupMailModuleTests
    {
        [Fact]
        public void PropagatesCallerInfoThroughExceptionDuringSignaling()
        {
            var module = new TestErrorMailModule();
            var mocks = new { Context = new Mock<HttpContextBase> { DefaultValue = DefaultValue.Mock } };
            using (var app = new HttpApplication())
            {
                var context = mocks.Context.Object;
                var callerInfo = new CallerInfo("foobar", "baz.cs", 42);
                var exception = new Exception();
                IDictionary actualData = null;
                module.OnErrorOverride = (e, _) => actualData = new Hashtable(e.Data);
                
                module.OnErrorSignaled(app, new ErrorSignalEventArgs(exception, context, callerInfo));

                Assert.Equal(0, exception.Data.Count);
                Assert.NotNull(actualData);
                Assert.Equal(1, actualData.Count);
                var actualCallerInfo = (CallerInfo) actualData.Cast<DictionaryEntry>().First().Value;
                Assert.Same(callerInfo, actualCallerInfo);

                module.OnErrorOverride = delegate { throw new TestException(); };

                Assert.Throws<TestException>(() => module.OnErrorSignaled(app, new ErrorSignalEventArgs(exception, context, callerInfo)));
                Assert.Equal(0, exception.Data.Count);
            }
        }

        sealed class TestErrorMailModule : ErrorGroupMailModule
        {
            public Action<Exception, HttpContextBase> OnErrorOverride { private get; set; }

            public new void OnErrorSignaled(object sender, ErrorSignalEventArgs args)
            {
                base.OnErrorSignaled(sender, args);
            }

            protected override void OnError(Exception e, HttpContextBase context)
            {
                (OnErrorOverride ?? base.OnError)(e, context);
            }
        }
    }
}
