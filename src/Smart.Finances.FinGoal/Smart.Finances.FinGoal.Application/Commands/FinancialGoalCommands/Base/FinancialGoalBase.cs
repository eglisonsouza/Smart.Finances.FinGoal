﻿using Smart.Finances.FinGoal.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Base
{
    public abstract class FinancialGoalBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal GoalAmount { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? IdealMonthySaving { get; set; }

        public FinancialGoal ToEntity()
        {
            return new FinancialGoal(Name, GoalAmount, Deadline, IdealMonthySaving);
        }
    }
}
