using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            //Business codes : İş gereksinimleri .. 
            //Validation     : İş kuralllarına yapısal olarak uygun mu diye kontrol eder. 

            //Bu kuralları her seferinde yazmak yerine bunu bir kere merkezi bir yerde yazarız. Fluent validation ile...

            //var context = new ValidationContext<Brand>(brand);
            //BrandValidator brandValidator = new BrandValidator();
            //var result = brandValidator.Validate(context);
            //if (!result.IsValid)                                          ==> Bu fluent validation her seferınde yazmamak icin -- core -- CrossCuttingConcerns 
            //{                                                             tarafında generic hale getirdik ve oradan her yere cagirabilecegiz...
            //    throw new ValidationException(result.Errors);
            //}

            ValidationTool.Validate(new BrandValidator(),brand);  // Olusturdumuz generic validator

            _brandDal.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            var brand = _brandDal.GetById(x => x.BrandId == id);
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ProductsDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductsListed.ToString());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(p => p.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ProductsUpdated);
        }
    }
}
