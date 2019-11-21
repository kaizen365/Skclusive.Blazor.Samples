using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.Blazor.TodoApp.Models;

namespace Skclusive.Blazor.TodoApp.Tests
{
    public class TestTodoList
    {
        [Fact]
        public void TestCreateTodoList()
        {
            var list = ModelTypes.TodoListType.Create(new ITodoSnapshot[]
            {
                new TodoSnapshot { Title = "Get coffee" }
            });

            Assert.Equal(1, list.Count);

            list.Unprotected();

            list.Insert(0, ModelTypes.TodoType.Create(new TodoSnapshot { Title = "Learn Blazor" }));

            var snapshots = list.GetSnapshot<ITodoSnapshot[]>();

            Assert.Equal(2, snapshots.Length);
        }

        [Fact]
        public void TestAddItemToTodoList()
        {
            var list = ModelTypes.TodoListType.Create(new ITodoSnapshot[]
            {
                new TodoSnapshot { Title = "Get coffee" }
            });

            Assert.Equal(1, list.Count);

            list.Unprotected();

            list.Insert(0, ModelTypes.TodoType.Create(new TodoSnapshot { Title = "Learn Blazor" }));

            Assert.Equal(2, list.Count);

            var snapshots = list.GetSnapshot<ITodoSnapshot[]>();

            Assert.Equal(2, snapshots.Length);
        }
    }
}
