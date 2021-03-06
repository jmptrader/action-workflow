using ActionWorkflow.Tracing;
using System;
using System.Linq;
using Xunit;

namespace ActionWorkflow.Tests
{
    public class ActionSequenceFactoryBuilderTests
    {
        [Fact]
        public void AddActionsTest()
        {
            var builder = new ActionSequenceFactoryBuilder<IActionTracingContainer>();
            builder.AddAction<DummyActionOne>();
            builder.AddAction(typeof(DummyActionTwo));

            var types = builder.ToCollection();

            Assert.True(types.Count == 2);
            Assert.True(types.ElementAt(0) == typeof(DummyActionOne));
            Assert.True(types.ElementAt(1) == typeof(DummyActionTwo));
        }

        [Fact]
        public void AddWrongTypeTest()
        {
            var builder = new ActionSequenceFactoryBuilder<string>();

            Assert.Throws<InvalidOperationException>(() => builder.AddAction(typeof(string)));
            Assert.Throws<InvalidOperationException>(() => builder.AddAction(typeof(IAction<string>)));
        }
    }
}