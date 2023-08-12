using MemberRegistration.Business.Abstract;
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

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public void Add(Member member)
        {
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
