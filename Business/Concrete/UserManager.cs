using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
          IResult result=BusinessRules.Run(CheckIfUserNameLengthCorrect(user), CheckIfUserName(user.FirstName));

            if (result!=null)
            {
                return result;
            }
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);        
        }

        public IResult Delete(int id)
        {
            var user = _userDal.GetById(x => x.Id == id);
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IDataResult<List<User>> GetAll()
        {
            if (_userDal.GetAll().Count == 0)
            {
                return new ErrorDataResult<List<User>>(_userDal.GetAll(), Messages.SaveFailed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(u => u.Id == id), Messages.UserByIdListed);
        }

        private IResult CheckIfUserNameLengthCorrect(User user)
        {
            if (user.FirstName.Length < 5)
            {
                return new ErrorResult(Messages.SaveFailed);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserName(string userName)
        {
            //Aynı isimde ürün var mı ? 
            var result = _userDal.GetAll(x => x.FirstName == userName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
          
        }
    }
}
