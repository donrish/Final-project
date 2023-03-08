using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelsProject.Models;
using Microsoft.Extensions.Logging;

namespace DelsProject.Services
{
    public class ExecutiveManager : IRepo<Executive>
    {
        public DeliveryContext _context;
        public ILogger<ExecutiveManager> _logger;
        public ExecutiveManager(DeliveryContext context, ILogger<ExecutiveManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Executive t)
        {
            try
            {
                _context.Executives.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

       
        public Executive Get(int id)
        {
            try
            {
                Executive executive = _context.Executives.FirstOrDefault(a => a.Id == id);
                return executive;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        
        public IEnumerable<Executive> GetAll()
        {
            try
            {
                if ((_context.Executives) == null)
                    return null;
                return _context.Executives.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;

        }

        public IEnumerable<Executive> GetAll(Executive t)
        {
            throw new NotImplementedException();
        }

        public int Login(Executive t)
        {
            Executive obj = _context.Executives.Where(i => i.UserName.Equals(t.UserName) && i.Password.Equals(t.Password) && i.IsVerified).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.Id;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        public void Update(int id, Executive t)
        {
            Executive executive = Get(id);
            if (executive != null)
            {
                executive.IsVerified = t.IsVerified;

            }
            _context.SaveChanges();
        }

        public void UpdateOrder(int id, Executive t)
        {
            throw new NotImplementedException();
        }
        public void CancelBooking(Executive t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Executive t)
        {
            throw new NotImplementedException();
        }

    }
}

