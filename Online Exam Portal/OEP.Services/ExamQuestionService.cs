﻿using OEP.Core.Data.Repository;
using OEP.Core.DomainModels.ExamModels;
using OEP.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEP.Services
{
   public  class ExamQuestionService:BaseService<ExamQuestion>, IExamQuestionService
    {
        public ExamQuestionService(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
