using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestaurantManager.Extensions;

namespace RestaurantManager.Model.DTOs
{
    public class ReservationDayDTO
    {
        public string Day { get; }
        public DateTime Value { get; }
        public string Position { get; }
        public bool HasReservations { get; }
        public bool IsVisible { get; }
        

        public ReservationDayDTO (DateTime date, bool hasReservations, bool isVisible = true, string position = null)
        {
            Day = date.Day.ToString();
            Position = position ?? ((date.Day - 1) % 7).ToString();
            Value = date;
            HasReservations = hasReservations;
            IsVisible = isVisible;
        }
    }
    
    public static class ReservationDayDTOExtensions{
        public static ObservableCollection<ReservationDayDTO> FillGrid(this IEnumerable<ReservationDayDTO> weekdays)
        {
            var reservationDayDtos = weekdays.ToList();
            int leftoverDays = 7 - reservationDayDtos.Count;
            var lastDay = reservationDayDtos.Last();
            var lastDayIndex = (Int32.Parse(lastDay.Day) - 1) % 7;
            var empty = Enumerable.Range(0, leftoverDays).Select(position =>
                    new ReservationDayDTO(new DateTime(), false,
                        false, (position + lastDayIndex + 1).ToString()))
                .ToObservableCollection();
            
            return reservationDayDtos.Concat(empty).ToObservableCollection();
        }
    }
}