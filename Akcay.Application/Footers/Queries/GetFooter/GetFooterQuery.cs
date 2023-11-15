using Akcay.Application.Common.Models;
using Akcay.Application.Footers.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Footers.Queries.GetFooter;

public class GetFooterQuery : IRequest<BaseResponseModel<FooterDto>>
{
    public long Id { get; set; }
}