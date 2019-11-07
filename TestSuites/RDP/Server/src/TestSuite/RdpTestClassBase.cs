﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Protocols.TestSuites.Rdpbcgr;
using Microsoft.Protocols.TestSuites.Rdpedyc;
using Microsoft.Protocols.TestSuites.Rdpemt;
using Microsoft.Protocols.TestTools;
using Microsoft.Protocols.TestTools.StackSdk.RemoteDesktop.Rdpbcgr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Microsoft.Protocols.TestSuites.Rdp
{
    public abstract class RdpTestClassBase : TestClassBase
    {
        #region Adapter Instances
        protected RdpbcgrAdapter rdpbcgrAdapter;
        protected RdpemtAdapter rdpemtAdapter;
        protected RdpedycAdapter rdpedycAdapter;

        protected TestConfig testConfig;

        #endregion

        #region Class Initialization and Cleanup

        public static void BaseInitialize(TestContext context)
        {
            TestClassBase.Initialize(context);
            BaseTestSite.DefaultProtocolDocShortName = BaseTestSite.Properties["ProtocolName"];
        }

        public static void BaseCleanup()
        {
            TestClassBase.Cleanup();
        }
        #endregion

        #region Test Initialization and Cleanup
        protected override void TestInitialize()
        {
            testConfig = new TestConfig(Site);
            this.rdpbcgrAdapter = new RdpbcgrAdapter(testConfig); 
            this.rdpbcgrAdapter.Initialize(Site);

            this.rdpemtAdapter = new RdpemtAdapter(testConfig);
            this.rdpemtAdapter.Initialize(Site);

            this.rdpedycAdapter = new RdpedycAdapter(testConfig);
            this.rdpedycAdapter.Initialize(Site);
        }

        protected override void TestCleanup()
        {
            if (rdpbcgrAdapter != null)
            {
                rdpbcgrAdapter.Reset();
            }

            if (rdpemtAdapter != null)
            {
                rdpemtAdapter.Reset();
            }

            if (rdpedycAdapter != null)
            {
                rdpedycAdapter.Reset();
            }

            base.TestCleanup();
        }
        #endregion
    }
}