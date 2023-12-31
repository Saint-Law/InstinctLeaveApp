﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstinctLeaveApp.Data
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        public int NumbersOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
