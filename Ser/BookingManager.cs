using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelsProject.Models;
using Microsoft.Extensions.Logging;

namespace DelsProject.Services
{
    public class BookingManager : IRepo<Booking>
    {
        public DeliveryContext _context;
        public ILogger<BookingManager> _logger;
        public BookingManager(DeliveryContext context, ILogger<BookingManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Booking t)
        {
            try
            {
                _context.Bookings.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
        public void BookingDetails(Booking t)
        {
            try
            {
                Booking booking = Get(t.OrderID);
                _context.Bookings.Find(booking);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
        public void CancelBooking(Booking b)
        {
            try
            {
                Booking booking = Get(b.OrderID);
                _context.Remove(booking);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
       public Booking Get(int id)
        {
            try
            {
                Booking booking = _context.Bookings.FirstOrDefault(a => a.OrderID == id);
                return booking;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Booking> GetAll( )
        {
            try
            {
               
                if ((_context.Bookings) == null)
                    return null;
                return _context.Bookings.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
        public void Update(int id, Booking t)
        { 
            Booking booking= _context.Bookings.FirstOrDefault();
            booking = Get(id);
                if (booking != null)
                {
                    booking.ExecutiveID = t.ExecutiveID;
                    booking.PickUpAddress = t.PickUpAddress;
                    booking.DeliveryAddress = t.DeliveryAddress;
                    booking.PickUpDateTime = t.PickUpDateTime;
                    booking.WeightOfPackage = t.WeightOfPackage;
                }
                _context.SaveChanges();
        }
        public void UpdateOrder(int id, Booking t)
        {
            Booking booking = Get(id);
            if (booking != null)
            {
                booking.Price = t.Price;
                booking.BookingStatus = t.BookingStatus;
            }
            _context.SaveChanges();
        }
        public int Login(Booking t)
        {
            throw new NotImplementedException();
        }
  }

 }
