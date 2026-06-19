using AirTrack.Server.Data;
using AirTrack.Server.Models.Aircraft;
using Microsoft.EntityFrameworkCore;

namespace AirTrack.Server.Data
    {
    public class DbHelper
        {
        private readonly AirTrackContext _context;

        public DbHelper(AirTrackContext context)
            {
            _context = context;
            }

        // ADD AIRCRAFT
        public async Task AddAircraft(AircraftBase aircraft)
            {
            _context.AircraftBases.Add(aircraft);
            await _context.SaveChangesAsync();
            }

        // DELETE AIRCRAFT
        public async Task DeleteAircraft(int id)
            {
            var aircraft = await _context.AircraftBases.FindAsync(id);
            if (aircraft is null)
                return;

            _context.AircraftBases.Remove(aircraft);
            await _context.SaveChangesAsync();
            }

        // GET ALL AIRCRAFT
        public async Task<List<AircraftBase>> GetAllAircraft()
            {
            return await _context.AircraftBases.ToListAsync();
            }

        // GET ONE AIRCRAFT
        public async Task<AircraftBase?> GetAircraft(int id)
            {
            return await _context.AircraftBases.FindAsync(id);
            }
        }
    }
