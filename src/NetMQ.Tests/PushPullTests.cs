﻿using NUnit.Framework;

namespace NetMQ.Tests
{
    [TestFixture]
    public class PushPullTests
    {
        [Test]
        public void SimplePushPull()
        {
            using (NetMQContext context = NetMQContext.Create())
            {
                using (var pullSocket = context.CreatePullSocket())
                {
                    var port = pullSocket.BindRandomPort("tcp://127.0.0.1");

                    using (var pushSocket = context.CreatePushSocket())
                    {
                        pushSocket.Connect("tcp://127.0.0.1:" + port);

                        pushSocket.Send("hello");

                        bool more;
                        string m = pullSocket.ReceiveString(out more);

                        Assert.AreEqual("hello", m);
                    }
                }
            }
        }

        [Test]
        public void EmptyMessage()
        {
            using (NetMQContext context = NetMQContext.Create())
            {
                using (var pullSocket = context.CreatePullSocket())
                {
                    var port = pullSocket.BindRandomPort("tcp://127.0.0.1");

                    using (var pushSocket = context.CreatePushSocket())
                    {
                        pushSocket.Connect("tcp://127.0.0.1:" + port);

                        pushSocket.Send(new byte[300]);

                        bool more;
                        byte[] m = pullSocket.Receive(out more);

                        Assert.AreEqual(300, m.Length);
                    }
                }
            }
        }
    }
}
