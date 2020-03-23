using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
namespace LocalPlannerActiveDirectory
{
    public class ActiveDirectoryService
    {
        public List<GroupPrincipal> GetGroupsForUser(string username)
        {
            try
            {
                List<GroupPrincipal> result = new List<GroupPrincipal>();
                PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
                var userprincipal = UserPrincipal.FindByIdentity(principalContext, username);
                PrincipalSearchResult<Principal> authGroups = userprincipal.GetAuthorizationGroups();
                
                foreach (Principal o in authGroups)
                {
                    result.Add((GroupPrincipal)o);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

          
        }
    }
}
