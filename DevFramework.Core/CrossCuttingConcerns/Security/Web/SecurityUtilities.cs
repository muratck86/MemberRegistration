using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        private string[] customUserDatas;
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            customUserDatas = GetUserDatas(ticket);
            var identity = new Identity
            {
                Id = SetId(ticket),
                Name = SetName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIstAuthenticated()
            };
            return identity;
        }

        private string[] GetUserDatas(FormsAuthenticationTicket ticket)
        {
            var datas = ticket.UserData.Split('|');
            return datas;
        }

        private bool SetIstAuthenticated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            return customUserDatas[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            return customUserDatas[2];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            return customUserDatas[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            return customUserDatas[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            return new Guid(customUserDatas[4]);
        }
    }
}
