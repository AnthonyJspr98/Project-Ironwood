using System;
using System.Collections.Generic;
using Ironwood.Application.Matches.Commands;
using Ironwood.Application.Teams.Commands;
using Ironwood.Application.Tournaments.Commands;
using Ironwood.Application.Vouchers.Commands;
using Ironwood.Domain.Entities;
using Ironwood.Enums;
namespace Ironwood.UI.Models
{
    public class AdminVM
    {
        public string AdminEmail { get; set; }
        public Guid UID { get; set; }
        public AccessRole AccessRole { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Tournament> Tournaments {get; set;}
        public IEnumerable<Category> Categories { get; set; }
        
        public CreateMatchCommand CreateMatchCommand { get; set; }
        public CreateVoucherCodeCommand CreateVoucherCodeCommand { get; set; }
        public RegisterTeamCommand RegisterTeamCommand { get; set; }
        public RegisterTournamentCommand RegisterTournamentCommand { get; set; }
        public CreateMatchCategoryCommand CreateMatchCategoryCommand { get; set; }
        
    }
}