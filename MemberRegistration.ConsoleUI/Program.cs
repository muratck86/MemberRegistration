using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMemberService memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member
            {
                FirstName = "Name",
                LastName = "Kurt",
                DateOfBirth = new DateTime(1900,1,1),
                Email = "kurt.muratcan@gmail.com",
                TcNo = "12345678901"
            });
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
