namespace WebStoreProject.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next; 
        public TestMiddleware(RequestDelegate Next)
        {
                _Next = Next;
        }

        public async Task Invoke(HttpContext context)
        {
            //обработка информации из context.request

            _Next(context);

            ////ИЛИ сделать работу параллельно

            //var processing_task = _Next(context); 

            ////выполняем другие действия

            //await processing_task; // синхронизируемся с задачей
            ////дообработка данных в context.Response

            //-------------------

            //var controller_name = context.Request.RouteValues["controller"];
            //var action_name = context.Request.RouteValues["action"];

        }
    }
}
