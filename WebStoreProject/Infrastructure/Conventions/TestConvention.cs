using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Diagnostics;

namespace WebStoreProject.Infrastructure.Conventions
{
    public class TestConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            Debug.WriteLine(controller.ControllerName);
            //controller.Actions.Clear(); //добавление, изменение удаление действий из котнроллера
            //controller.RouteValues изменение маршрута к контроллеру
        }
    }
}
