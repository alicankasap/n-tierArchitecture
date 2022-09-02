using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.EmailParameterRepository
{
    public interface IEmailParameterService
    {
        Task<IDataResult<List<EmailParameter>>> GetList();
        IDataResult<EmailParameter> GetById(int id);
        IResult Add(EmailParameter emailParameter);
        IResult Update(EmailParameter emailParameter);
        IResult Delete(EmailParameter emailParameter);
        IResult SendEmail(EmailParameter emailParameter, string body, string subject, string emails);
    }
}
