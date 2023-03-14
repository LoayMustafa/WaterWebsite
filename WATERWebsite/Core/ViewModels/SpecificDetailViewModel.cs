﻿using WATERWebsite.Core.Models;

namespace WATERWebsite.Core.ViewModels
{
    public class SpecificDetailViewModel
    {
        public string SpecificsName { get; set; } = string.Empty;
        public string? SpecificsBrief { get; set; }
        public string? SpecificsOverview { get; set; }
        public string? SpecificsEnd { get; set; }
    }
}