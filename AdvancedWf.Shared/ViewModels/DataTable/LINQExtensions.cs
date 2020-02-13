using System.Collections.Generic;
using System.Security.Principal;

namespace AdvancedWf.Shared.ViewModels
{
    public static class LinqExtentions
    {
        /// <summary>
        /// Helper to know if user in any of specific roles
        /// </summary>
        /// <param name="user">current logged user - Dependancy injection</param>
        /// <param name="roles">List of string - roles names</param>
        /// <returns></returns>
        public static bool IsInAnyRole(this IPrincipal user, List<string> roles)
        {
            foreach (var item in roles)
                if (user.IsInRole(item)) return true;
            return false;
        }
    }
}
