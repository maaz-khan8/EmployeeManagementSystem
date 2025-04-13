using System;

namespace EmployeeManagementSystem.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public string PostedBy { get; set; }
    }
}
