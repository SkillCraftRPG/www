using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SkillCraft.Api.Extensions;

internal class AddHeaderParameters : IOperationFilter
{
  public void Apply(OpenApiOperation operation, OperationFilterContext context)
  {
    //operation.Parameters.Add(new OpenApiParameter
    //{
    //  In = ParameterLocation.Header,
    //  Name = Headers.World,
    //  Description = "Enter your world ID or unique slug in the input below:"
    //}); // TODO(fpion): implement
  }
}
