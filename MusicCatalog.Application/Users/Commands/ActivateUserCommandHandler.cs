using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Users.Commands
{
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserContextService _userContextService;

        public ActivateUserCommandHandler(UserManager<User> userManager, IUserContextService userContextService)
        {
            _userManager = userManager;
            _userContextService = userContextService;
        }

        public async Task<bool> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user is null)
            {
                return false;
            }
            user.IsActivated = true;
            user.ActivatedBy = await _userManager.FindByIdAsync(_userContextService.UserId.ToString());
            user.ActivatedOn = DateTime.UtcNow;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
