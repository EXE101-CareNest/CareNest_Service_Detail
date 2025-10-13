using CareNest_Service_Detail.Application.Interfaces.CQRS.Queries;
using CareNest_Service_Detail.Application.Interfaces.Services;
using CareNest_Service_Detail.Application.Interfaces.UOW;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdsQueryHandler : IQueryHandler<GetByIdsQuery, GetByIdsResponse>
    {
        private const int MaxIds = 1000;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceService _serviceService;

        public GetByIdsQueryHandler(IUnitOfWork unitOfWork, IServiceService serviceService)
        {
            _unitOfWork = unitOfWork;
            _serviceService = serviceService;
        }

        public async Task<GetByIdsResponse> HandleAsync(GetByIdsQuery query)
        {
            var response = new GetByIdsResponse();

            if (query.Ids == null || query.Ids.Count == 0)
            {
                return response;
            }

            var ids = query.Ids.Distinct().Take(MaxIds).ToList();

            IEnumerable<Service_Detail> entities = await _unitOfWork.GetRepository<Service_Detail>().FindAsync(
                predicate: s => ids.Contains(s.Id)
            );

            var foundIds = entities.Select(e => e.Id!).ToHashSet();
            response.NotFoundIds = ids.Where(id => !foundIds.Contains(id)).ToList();

            var serviceIdSet = entities.Select(e => e.ServiceId).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();
            var serviceIdToName = new Dictionary<string, string?>();
            foreach (var sid in serviceIdSet)
            {
                var info = await _serviceService.GetById(sid);
                serviceIdToName[sid!] = info.Data?.Data?.Name;
            }

            bool useProjection = query.Fields != null && query.Fields.Count > 0;
            HashSet<string> fields = useProjection ? new HashSet<string>(query.Fields!.Select(f => f.ToLower())) : new HashSet<string>();

            foreach (var e in entities)
            {
                var item = new ServiceDetailBatchItem();
                if (!useProjection || fields.Contains("id")) item.Id = e.Id;
                if (!useProjection || fields.Contains("serviceid")) item.ServiceId = e.ServiceId;
                if (!useProjection || fields.Contains("name")) item.Name = e.Name;
                if (!useProjection || fields.Contains("price")) item.Price = e.Price;
                if (!useProjection || fields.Contains("durationtime")) item.DurationTime = e.DurationTime;
                if (!useProjection || fields.Contains("status")) item.Status = e.Status;
                if (!useProjection || fields.Contains("discount")) item.Discount = e.Discount;
                if (!useProjection || fields.Contains("isdefault")) item.IsDefault = e.IsDefault;
                if (!useProjection || fields.Contains("imgurls")) item.ImgUrls = e.ImgUrls;
                if (!useProjection || fields.Contains("servicename"))
                {
                    if (!string.IsNullOrWhiteSpace(e.ServiceId) && serviceIdToName.TryGetValue(e.ServiceId, out var sname))
                    {
                        item.ServiceName = sname;
                    }
                }
                response.Items.Add(item);
            }

            response.Total = response.Items.Count;
            return response;
        }
    }
}


