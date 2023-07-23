﻿namespace MegaCarsSystem.Web.ViewModels.Agent
{
    using System.ComponentModel.DataAnnotations;

    public class AgentInfoOnCarViewModel
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}