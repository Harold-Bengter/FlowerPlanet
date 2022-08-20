using System.Security.Claims;

namespace FlowerPlanet;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal user) //instance reference
    {
        return user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
