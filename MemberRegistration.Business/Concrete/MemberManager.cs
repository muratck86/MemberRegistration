using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }

        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
                throw new Exception("Bu kullanıcı zaten kayıtlı!");

            if (!_kpsService.Validate(member))
                throw new Exception("Kullanıcı doğrulanamadı, bilgileri doğru girdiğinizden emin olunuz.");

            _memberDal.Add(member);
        }

        public void Delete(Member member)
        {
            _memberDal?.Delete(member);
        }

        public Member Get(int id)
        {
            return _memberDal.Get(m => m.Id == id);
        }

        public List<Member> GetAll()
        {
            return _memberDal.GetList();
        }

        public Member Update(Member member)
        {
            return _memberDal.Update(member);
        }
    }
}
