using Fermion.Domain.Shared.Filters;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Fermion.Domain.Shared.Conventions;

public class ControllerDisablingConvention(Type controllerType) : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType != controllerType)
        {
            return;
        }

        foreach (var action in controller.Actions)
        {
            action.Filters.Add(new DisableApiFilter());
        }
    }
}