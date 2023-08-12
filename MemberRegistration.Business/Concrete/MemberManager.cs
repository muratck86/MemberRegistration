using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
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

        public void Add(Member member)
        {
            if (_kpsService.Validate(member))
                _memberDal.Add(member);
            else
                throw new Exception("Kullanıcı doğrulanamadı, bilgileri doğru girdiğinizden emin olunuz.");
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
