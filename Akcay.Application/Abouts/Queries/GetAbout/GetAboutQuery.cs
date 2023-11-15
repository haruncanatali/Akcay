using Akcay.Application.Abouts.Queries.Dtos;
using Akcay.Application.Common.Models;
using MediatR;

namespace Akcay.Application.Abouts.Queries.GetAbout;

public class GetAboutQuery : IRequest<BaseResponseModel<AboutDto>>
{
    public long Id { get; set; }
}