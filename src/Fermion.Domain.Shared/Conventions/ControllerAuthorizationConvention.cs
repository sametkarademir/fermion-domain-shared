using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fermion.Domain.Shared.Conventions;

/// <summary>
/// This class is used to apply authorization policies to controllers.
/// It implements the IControllerModelConvention interface.
/// </summary>
/// <param name="controllerType">The type of the controller to apply the convention to.</param>
/// <param name="route">The route template to apply to the controller.</param>
/// <param name="requireAuthentication">Whether authentication is required.</param>
/// <param name="globalPolicy">The global authorization policy to apply.</param>
/// <param name="allowedRoles">The list of allowed roles for the controller.</param>
public class ControllerAuthorizationConvention(
    Type controllerType,
    string route,
    bool requireAuthentication,
    string? globalPolicy,
    List<string>? allowedRoles)
    : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType != controllerType)
        {
            return;
        }

        if (!requireAuthentication && string.IsNullOrEmpty(globalPolicy) && allowedRoles == null)
        {
            return;
        }

        foreach (var selector in controller.Selectors)
        {
            if (selector.AttributeRouteModel != null)
            {
                selector.AttributeRouteModel.Template = route;
            }
        }

        var existingFilters = controller.Filters
            .OfType<IAuthorizationFilter>()
            .Where(f => f is AuthorizeFilter)
            .ToList();

        foreach (var filter in existingFilters)
        {
            controller.Filters.Remove(filter);
        }

        if (requireAuthentication && allowedRoles is { Count: > 0 })
        {
            controller.Filters.Add(new AuthorizeFilter(
                [
                    new AuthorizeAttribute
                    {
                        Roles = string.Join(",", allowedRoles)
                    }
                ]
            ));
        }
        else if (requireAuthentication && !string.IsNullOrEmpty(globalPolicy))
        {
            controller.Filters.Add(new AuthorizeFilter(globalPolicy));
        }
        else if (requireAuthentication)
        {
            controller.Filters.Add(new AuthorizeFilter());
        }
    }
}