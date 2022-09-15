using Core.Application.Requests;
using Devs.Application.Models;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Queries.GetList;

public class GetListSocialProfileQuery : IRequest<SocialProfileListModel>
{
    public PageRequest PageRequest { get; set; }

   
}
