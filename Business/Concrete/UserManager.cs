using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            _userDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            var user = _userDal.GetById(x => x.Id == id);
            _userDal.Delete(user);
            return new SuccessResult(Messages.ProductsDeleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.ProductsUpdated);
        }
        public IDataResult<List<User>> GetAll()
        {
            if (_userDal.GetAll().Count == 0)
            {
                return new ErrorDataResult<List<User>>(_userDal.GetAll(), Messages.SaveFailed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(u => u.Id == id), Messages.ProductsListed);
        }
    }
}
