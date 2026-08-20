using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models.ViewModels
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }

        public string Alias { get; set; } = null!;

        public DateOnly Date { get; set; }

        public bool BreakFast { get; set; }

        public bool Lunch { get; set; }

        public bool Dinner { get; set; }

        public int AttId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
