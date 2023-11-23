using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    
    public class UnitTest1
    {
        private readonly EventsController _eventsController;
        public UnitTest1()
        {
            var context = new DataContextFake();
            _eventsController = new EventsController(context);
        }

        [Fact]
        public void ReturnOk_Get()
        {
           // var controller = new EventsController();
            var result = _eventsController.Get();
           // Assert.NotNull(result);
           Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ReturnOk_GetByID()
        {
            int id = 9;
          //  var controller = new EventsController();
            var result = _eventsController.Get(id);
            // Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}