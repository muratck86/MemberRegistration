﻿using MemberRegistration.Business.KpsServiceReference;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.ServiceAdapters
{
    public class KpsServiceAdapter : IKpsService
    {
        public bool Validate(Member member)
        {
            KpsServiceReference.KPSPublicSoapClient client = new KPSPublicSoapClient();
            var result = client.TCKimlikNoDogrula(
                Convert.ToInt64(member.TcNo),
                member.FirstName.ToUpper(),
                member.LastName.ToUpper(),
                member.DateOfBirth.Year);
            return result;
        }
    }
}
