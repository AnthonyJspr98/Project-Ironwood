using System;
using Ironwood.Application.Teams.Commands;
using Ironwood.Application.Tournaments.Commands;
using Ironwood.Application.Vouchers.Commands;
using Ironwood.Enums;
namespace Ironwood.UI.Models
{
    public class AdminVM
    {
        public string AdminEmail { get; set; }
        public Guid UID { get; set; }
        public AccessRole AccessRole { get; set; }
        
        public CreateVoucherCodeCommand CreateVoucherCodeCommand { get; set; }
        public RegisterTeamCommand RegisterTeamCommand { get; set; }
        public RegisterTournamentCommand RegisterTournamentCommand { get; set; }
        
    }
}