using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail;

namespace CleanArchitecture.Service.CompoundEntities
{
    public class CompoundEntitiesController : ApiController
    {
        private readonly IGetCompoundEntitiesListQuery _listQuery;
        private readonly IGetCompoundEntityDetailQuery _detailQuery;
        private readonly ICreateCompoundEntityCommand _createCommand;

        public CompoundEntitiesController(
            IGetCompoundEntitiesListQuery listQuery,
            IGetCompoundEntityDetailQuery detailQuery,
            ICreateCompoundEntityCommand createCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
        }

        public IEnumerable<CompoundEntitiesListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        public CompoundEntityDetailModel Get(int id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateCompoundEntityModel compoundEntity)
        {
            _createCommand.Execute(compoundEntity);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
