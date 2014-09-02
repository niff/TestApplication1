﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IglaClub.ObjectModel.Enums;

namespace IglaClub.ObjectModel.Entities
{
    public class Tournament : BaseEntity
    {
        [Required(ErrorMessage="The name is required")]
        public string  Name { get; set; }

        public string Description { get; set; }

        public virtual Club Club { get; set; }

        [DisplayName("Tournament Scoring Type")]
        public TournamentScoringType TournamentScoringType { get; set; }

        [DisplayName("Tournament Moving Type")]
        public TournamentMovingType TournamentMovingType { get; set; }

        public virtual IList<Pair> Pairs { get; set; }

        [DisplayName ("Boards in round")]
        [Required(ErrorMessage = "The boards in round field is required")]
        public int BoardsInRound { get; set; }

        public virtual IList<BoardInstance> Boards { get; set; }

        public virtual IList<Result> Results { get; set; }

        [DisplayName ("Tournament Status")]
        public TournamentStatus TournamentStatus { get; set; }

        [DisplayName ("Current Round")]
        public int CurrentRound { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Planned Start Date")]
        public DateTime? PlannedStartDate { get; set; }

        [DisplayName("Creation Date")]
        public DateTime? CreationDate { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Finish Date")]
        public DateTime? FinishDate { get; set; }

        [DisplayName("Created by")]
        virtual public User Owner { get; set; }

        public bool UserIsSubscribed(string login)
        {
            if (this.Pairs == null)
                return false;
            return this.Pairs.Any(p => (p.Player1 != null && p.Player1.Login == login) || (p.Player2 != null && p.Player2.Login == login));
        }
     }
}