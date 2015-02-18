﻿using System.Collections.Generic;
using IglaClub.ObjectModel.Entities;

namespace IglaClub.Web.Models.ViewModels
{
    public class PairsViewModel
    {
        public Tournament Tournament { get; set; }
        public List<Pair> PairsInTounament { get; set; }
        public List<User> AvailableUsers { get; set; }
        public User CurrentUser { get; set; }

        public User NewUser { get; set; }
    }
    
}