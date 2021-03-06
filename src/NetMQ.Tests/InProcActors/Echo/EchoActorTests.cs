﻿using System;
using NetMQ.Actors;
using NUnit.Framework;

namespace NetMQ.Tests.InProcActors.Echo
{
    [TestFixture]
    public class EchoActorTests
    {
        [TestCase("I like NetMQ")]
        [TestCase("NetMQ Is quite awesome")]
        [TestCase("Agreed sockets on steroids with isotopes")]
        public void EchoActorSendReceiveTests(string actorMessage)
        {
            using (var context = NetMQContext.Create())
            {
                EchoShimHandler echoShimHandler = new EchoShimHandler();
                using (Actor<string> actor = new Actor<string>(context, echoShimHandler, "Hello World"))
                {
                    actor.SendMore("ECHO");
                    actor.Send(actorMessage);
                    var result = actor.ReceiveString();
                    string expectedEchoHandlerResult = string.Format("ECHO BACK : {0}", actorMessage);
                    Assert.AreEqual(expectedEchoHandlerResult, result);
                }
            }
        }

        [TestCase("BadCommand1")]
        public void BadCommandTests(string command)
        {
            using (var context = NetMQContext.Create())
            {
                string actorMessage = "whatever";
                EchoShimHandler echoShimHandler = new EchoShimHandler();
                using (Actor<string> actor = new Actor<string>(context, echoShimHandler, "Hello World"))
                {
                    actor.SendMore(command);
                    actor.Send(actorMessage);
                    var result = actor.ReceiveString();
                    string expectedEchoHandlerResult = "Error: invalid message to actor";
                    Assert.AreEqual(expectedEchoHandlerResult, result);
                }
            }
        }

        [TestCase("")]
        [TestCase("12131")]
        [TestCase("Hello")]
        public void BadStatePassedToActor(string stateForActor)
        {
            using (var context = NetMQContext.Create())
            {
                //string actorMessage = "whatever";
                EchoShimHandler echoShimHandler = new EchoShimHandler();

                try
                {
                    //this will throw in this testcase, asw are supplying bad state for this EchoHandler
                    using (Actor<string> actor = new Actor<string>(context, echoShimHandler, stateForActor))
                    {
                        
                    }
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Args were not correct, expected 'Hello World'", e.Message);
                }
            }
        }
    }

}

