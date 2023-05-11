﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerApi.Models
{
	public class BugEntity
	{
		public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}"), Required]
        public DateOnly Date { get;set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string Priority { get; set; }
		[Required]
		public string Assignment { get; set; }
	}
}

